using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList
{
    public interface ITodosService
    {
        Task<IList<TodoItem>> GetTodoItemsAsync();

        Task AddTodoItemAsync(TodoItem todoItem);

        Task CompleteTodoItemAsync(int todoItemId);

        Task MarkAsTodoItemAsInCompleteAsync(int todoItemId);
    }
}
