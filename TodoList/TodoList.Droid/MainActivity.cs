using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using TodoList.Models;

namespace TodoList.Droid
{
	[Activity (Label = "My Todo List", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

        TodoItemListAdapter _taskListAdapter;
        Button _addTodoButton;
        ListView _todoList;
	    EditText _todoText;
	    readonly ITodosService _todosService = new TodosService();

        protected override async void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            //Find our controls
            _todoList = FindViewById<ListView>(Resource.Id.TodoList);
            _addTodoButton = FindViewById<Button>(Resource.Id.AddButton);
            _todoText = FindViewById<EditText>(Resource.Id.TodoText);


            _taskListAdapter = new TodoItemListAdapter(this, await _todosService.GetTodoItemsAsync());
            _todoList.Adapter = _taskListAdapter;


            _addTodoButton.Click += async (sender, e) =>
            {
                await AddTodoItem();
            };

            _todoText.KeyPress += async (sender, e) =>
            {
                e.Handled = false;
                if (e.Event.Action != KeyEventActions.Down 
                || e.KeyCode != Keycode.Enter) return;
                e.Handled = true;

                await AddTodoItem();
            };

            _todoList.ItemClick += async (sender, args) =>
            {
                var todoItem = _taskListAdapter[args.Position];
                if (todoItem.Done)
                {
                    await _todosService.MarkAsTodoItemAsInCompleteAsync(todoItem);
                }
                else
                {
                    await _todosService.CompleteTodoItemAsync(todoItem);

                }
                RefreshList();
            };
		}

	    private async Task AddTodoItem()
	    {
	        if (!string.IsNullOrEmpty(_todoText.Text))
	        {
                var todo = new TodoItem
                {
                    Name = _todoText.Text
                };
                _todoText.Text = string.Empty;

                HideSoftKeyboard();

	            await _todosService.AddTodoItemAsync(todo);
                RefreshList();
            }
        }

	    private void HideSoftKeyboard()
	    {
	        var imm = (InputMethodManager) GetSystemService(InputMethodService);
	        imm.HideSoftInputFromWindow(_todoText.WindowToken, 0);
	    }

	    protected override void OnResume()
	    {
	        base.OnResume();
	        RefreshList();
	    }

	    private void RefreshList()
	    {
            _taskListAdapter.NotifyDataSetChanged();

        }

	}
}


