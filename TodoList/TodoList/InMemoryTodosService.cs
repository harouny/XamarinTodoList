using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList
{
    public class InMemoryTodosService : ITodosService
    {
        private readonly List<TodoItem> _todoItems = new List<TodoItem>();

        public InMemoryTodosService()
        {
            _todoItems.Add(new TodoItem()
            {
                Name = "Item one"
            });

            _todoItems.Add(new TodoItem()
            {
                Name = "Item two"
            });
        }

        public async Task<IList<TodoItem>> GetTodoItemsAsync()
        {
            return await Task.FromResult(_todoItems);
        }

        public async Task AddTodoItemAsync(TodoItem todoItem)
        {
            await Task.Run(() => _todoItems.Add(todoItem));
        }

        public async Task CompleteTodoItemAsync(int todoItemId)
        {

            await Task.Run(() =>
            {
                var todoItem = _todoItems
                .Single(obj => obj.Id == todoItemId);
                todoItem.Complete();
            });
        }

        public async Task MarkAsTodoItemAsInCompleteAsync(int todoItemId)
        {
            await Task.Run(() =>
            {
                var todoItem = _todoItems
                .Single(obj => obj.Id == todoItemId);
                todoItem.MarkAsIncomplete();
            });
        }
    }
}

