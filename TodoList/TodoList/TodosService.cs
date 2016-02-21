using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using TodoList.DataAccess;
using TodoList.Models;

namespace TodoList
{
    public class TodosService : ITodosService
    {
        private readonly TodoDatabase _db;
        private readonly List<TodoItem> _todoItems; 

        public TodosService(string databasePath)
        {
            _db = new TodoDatabase(new SQLiteConnection(databasePath));
            _todoItems = _db.GetItems().ToList();
        }

        public async Task<IList<TodoItem>> GetTodoItemsAsync()
        {
            return await Task.FromResult(_todoItems);
        }

        public async Task AddTodoItemAsync(TodoItem todoItem)
        {
            await Task.Run(() => 
            {
                    _db.SaveItem(todoItem);
                    _todoItems.Add(todoItem);
            });
        }

        public async Task CompleteTodoItemAsync(TodoItem todoItem)
        {
            await Task.Run(() =>
            {
                var item = _todoItems.Single(obj => obj.Id == todoItem.Id);
                item.Complete();
                _db.SaveItem(item);
            });
        }

        public async Task MarkAsTodoItemAsInCompleteAsync(TodoItem todoItem)
        {
            await Task.Run(() =>
            {
                var item = _todoItems.Single(obj => obj.Id == todoItem.Id);
                item.MarkAsIncomplete();
                _db.SaveItem(item);
            });
        }
    }
}

