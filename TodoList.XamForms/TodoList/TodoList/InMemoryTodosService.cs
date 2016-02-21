using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList
{
    public class InMemoryTodosService : ITodosService
    {
        public ObservableCollection<TodoItem> TodoItems { get; } = new ObservableCollection<TodoItem>();

        public InMemoryTodosService()
        {
            TodoItems.Add(new TodoItem()
            {
                Name = "Item one",
                Id = 1
            });

            TodoItems.Add(new TodoItem()
            {
                Name = "Item two",
                Id = 2
            });
        }

        public async Task<ObservableCollection<TodoItem>> GetTodoItemsAsync()
        {
            return await Task.FromResult(TodoItems);
        }

        public async Task AddTodoItemAsync(TodoItem todoItem)
        {
            await Task.Run(() => TodoItems.Add(todoItem));
        }

        public async Task CompleteTodoItemAsync(int todoItemId)
        {

            await Task.Run(() =>
            {
                var todoItem = TodoItems
                .Single(obj => obj.Id == todoItemId);
                todoItem.Complete();
            });
        }

        public async Task MarkAsTodoItemAsInCompleteAsync(int todoItemId)
        {
            await Task.Run(() =>
            {
                var todoItem = TodoItems
                .Single(obj => obj.Id == todoItemId);
                todoItem.MarkAsIncomplete();
            });
        }
    }
}

