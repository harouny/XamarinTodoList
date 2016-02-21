using System.Collections.Generic;
using System.Linq;
using SQLite;
using TodoList.Models;

namespace TodoList.DataAccess
{
	public class TodoDatabase 
	{
	    private static readonly object Locker = new object ();

		public SQLiteConnection Database;

		public string Path;

		public TodoDatabase (SQLiteConnection conn) 
		{
			Database = conn;
			Database.CreateTable<TodoItem>();
		}

		public IEnumerable<TodoItem> GetItems ()
		{
			lock (Locker) {
				return (from i in Database.Table<TodoItem>() select i).ToList();
			}
		}

		public TodoItem GetItem (int id) 
		{
			lock (Locker) {
				return Database.Table<TodoItem>().FirstOrDefault(x => x.Id == id);
			}
		}

		public int SaveItem (TodoItem item) 
		{
			lock (Locker)
			{
			    if (item.Id == 0) return Database.Insert(item);
			    Database.Update(item);
			    return item.Id;
			}
		}

		public int DeleteItem(int id) 
		{
			lock (Locker) {
				return Database.Delete<TodoItem>(id);
			}
		}
	}
}