using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList
{
    public interface ITodosService
    {
        Task<IEnumerable<TodoItem>> GetTodoItemsAsync();

        Task AddTodoItemAsync(TodoItem todoItem);

        Task CompleteTodoItemAsync(TodoItem todoItem);
    }
}
