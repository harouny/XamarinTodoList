using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using TodoList.DataAccess;
using TodoList.Models;
using Xamarin.Forms;

namespace TodoList
{
    public class TodosService : ITodosService
    {
        private readonly TodoDatabase _db;
        public ObservableCollection<TodoItem> TodoItems { get; }

        public TodosService()
        {
            var databasePath = DependencyService.Get<ISqLiteDbPathProvider>().GetDbPath();
            _db = new TodoDatabase(new SQLiteConnection(databasePath));
            TodoItems = new ObservableCollection<TodoItem>(_db.GetItems());
        }

        public async Task<ObservableCollection<TodoItem>> GetTodoItemsAsync()
        {
            return await Task.FromResult(TodoItems);
        }

        public async Task AddTodoItemAsync(TodoItem todoItem)
        {
            await Task.Run(() => 
            {
                    _db.SaveItem(todoItem);
                    TodoItems.Add(todoItem);
            });
        }

        public async Task CompleteTodoItemAsync(int todoItemId)
        {
            await Task.Run(() =>
            {
                var item = TodoItems
                .Single(obj => obj.Id == todoItemId);
                item.Complete();
                _db.SaveItem(item);
            });
        }

        public async Task MarkAsTodoItemAsInCompleteAsync(int todoItemId)
        {
            await Task.Run(() =>
            {
                var item = TodoItems
                .Single(obj => obj.Id == todoItemId);
                item.MarkAsIncomplete();
                _db.SaveItem(item);
            });
        }
    }
}

