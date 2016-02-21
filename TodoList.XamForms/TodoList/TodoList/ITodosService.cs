using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList
{
    public interface ITodosService
    {
        Task<ObservableCollection<TodoItem>> GetTodoItemsAsync();

        Task AddTodoItemAsync(TodoItem todoItem);

        Task CompleteTodoItemAsync(int todoItemId);

        Task MarkAsTodoItemAsInCompleteAsync(int todoItemId);

        ObservableCollection<TodoItem> TodoItems { get; }

    }
}
