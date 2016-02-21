using System;
using System.Collections.Generic;
using Foundation;
using TodoList.Models;
using UIKit;

namespace TodoList.iOS
{
    public class TodoTableViewSource : UITableViewSource
    {
        readonly IList<TodoItem> _tasks;
        private readonly ITodosService _todosService;
        const string CellIdentifier = "TodoItemTableCell";

        public TodoTableViewSource(IList<TodoItem> tasks, ITodosService todosService)
        {
            _tasks = tasks;
            _todosService = todosService;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier);
            var item = _tasks[indexPath.Row];

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            }

            cell.Accessory = item.Done ? UITableViewCellAccessory.Checkmark 
                                       : UITableViewCellAccessory.None;
            cell.TextLabel.Text = item.Name;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _tasks.Count;
        }

        public override async void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var item = _tasks[indexPath.Row];
            if (!item.Done)
            {
                await _todosService.CompleteTodoItemAsync(item.Id);
            }
            else
            {
                await _todosService.MarkAsTodoItemAsInCompleteAsync(item.Id);
            }
            tableView.ReloadRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
            tableView.DeselectRow(indexPath, true);
        }
    }
}
