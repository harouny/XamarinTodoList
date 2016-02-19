using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TodoList.Models;

namespace TodoList.Droid
{
	[Activity (Label = "TodoList.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

        TodoItemListAdapter _taskListAdapter;
        IList<TodoItem> _tasks;
        Button _addTodoButton;
        ListView _todoList;
	    EditText _todoText;
	    readonly ITodosService _todosService = new TodosService();

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            //Find our controls
            _todoList = FindViewById<ListView>(Resource.Id.TodoList);
            _addTodoButton = FindViewById<Button>(Resource.Id.AddButton);
            _todoText = FindViewById<EditText>(Resource.Id.TodoText);

            _addTodoButton.Click += (sender, e) =>
            {
                var todo = new TodoItem();
                _tasks.Add(todo);
                _todosService.AddTodoItemAsync(todo);
            };
        }

	    protected override void OnResume()
	    {
	        base.OnResume();

	        _tasks = _todosService.GetTodoItemsAsync().Result.ToList();

            // create our adapter
            _taskListAdapter = new TodoItemListAdapter(this, _tasks);

            //Hook up our adapter to our ListView
            _todoList.Adapter = _taskListAdapter;
        }
	}
}


