using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList
{
    public interface ITodosService
    {
        Task<IList<TodoItem>> GetTodoItemsAsync();

        Task AddTodoItemAsync(TodoItem todoItem);

        Task CompleteTodoItemAsync(TodoItem todoItem);

        Task MarkAsTodoItemAsInCompleteAsync(TodoItem todoItem);
    }
}
