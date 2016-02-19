using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList
{
    public class TodosService : ITodosService
    {
        private readonly List<TodoItem> _todoItems = new List<TodoItem>(); 

        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            return await Task.FromResult(_todoItems);
        }

        public async Task AddTodoItemAsync(TodoItem todoItem)
        {
            await Task.Run(() => _todoItems.Add(todoItem));
        }

        public async Task CompleteTodoItemAsync(TodoItem todoItem)
        {
            await Task.Run(() => todoItem.Complete());
        }
    }
}

