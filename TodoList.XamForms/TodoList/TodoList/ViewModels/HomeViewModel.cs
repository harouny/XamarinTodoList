using System.Collections.ObjectModel;
using System.Windows.Input;
using TodoList.Models;
using Xamarin.Forms;

namespace TodoList.ViewModels
{
    public class HomeViewModel
    {
        private readonly ITodosService _todoService = new TodosService();

        public HomeViewModel()
        {
            AddTodoCommand = new Command(ExecuteAddTodoCommand);
            TodoItems = _todoService.GetTodoItemsAsync().Result;
        }
        

        public ObservableCollection<TodoItem> TodoItems { get; set; }

        public string TodoText { get; set; }

        public ICommand AddTodoCommand { get; set; }

        private async void ExecuteAddTodoCommand()
        {
            var todoItem = new TodoItem
            {
                Name = TodoText
            };
            await _todoService.AddTodoItemAsync(todoItem);
        }

        public async void SignalTodoItemChangedAsync(TodoItem todoItem)
        {
            if (todoItem.Done)
            {
                await _todoService.CompleteTodoItemAsync(todoItem.Id);
            }
            else
            {
                await _todoService.MarkAsTodoItemAsInCompleteAsync(todoItem.Id);
            }
        }
    }
}
