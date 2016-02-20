using System;
using System.Threading.Tasks;
using TodoList.Models;
using UIKit;

namespace TodoList.iOS
{
	public partial class ViewController : UIViewController
	{
		ITodosService _todosService = new TodosService();

		public ViewController (IntPtr handle) : base (handle)
		{
            UITableView.Appearance.TintColor = UIColor.FromRGB(0x6F, 0xA2, 0x2E);
        }

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            await PopulateTable();
		}

        protected async Task PopulateTable()
        {
            TodoTableView.Source = new TodoTableViewSource(await _todosService.GetTodoItemsAsync());
        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        async partial void AddBtn_TouchUpInside(UIButton sender)
        {
            var todoItem = new TodoItem()
            {
                Name = TodoText.Text
            };
            await _todosService.AddTodoItemAsync(todoItem);
            TodoTableView.ReloadData();
        }
    }
}

