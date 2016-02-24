using System;
using System.IO;
using System.Threading.Tasks;
using TodoList.Models;
using UIKit;

namespace TodoList.iOS
{
	public partial class ViewController : UIViewController
	{
	    private ITodosService _todosService;

		public ViewController (IntPtr handle) : base (handle)
		{
            UITableView.Appearance.TintColor = UIColor.FromRGB(0x6F, 0xA2, 0x2E);
        }

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		    if (_todosService == null)
		    {
                // Create the database file
                var sqliteFilename = "TodoItemDB4.db3";
                // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
                // (they don't want non-user-generated data in Documents)
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
                var path = Path.Combine(libraryPath, sqliteFilename);
                _todosService = new TodosService(path);
            }

            await PopulateTable();
		}

        protected async Task PopulateTable()
        {
            TodoTableView.Source = new TodoTableViewSource(await _todosService.GetTodoItemsAsync(), _todosService);
        }


	    // ReSharper disable once UnusedMember.Local
	    // ReSharper disable once UnusedParameter.Local
        async partial void AddBtn_TouchUpInside(UIButton sender)
        {
            var todoItem = new TodoItem
            {
                Name = TodoText.Text
            };
            TodoText.Text = string.Empty;
            await _todosService.AddTodoItemAsync(todoItem);
            TodoText.ResignFirstResponder();
            TodoTableView.ReloadData();
        }




    }
}

