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
        const string CellIdentifier = "TableCell";

        public TodoTableViewSource(IList<TodoItem> tasks)
        {
            _tasks = tasks;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier);
            var item = _tasks[indexPath.Row];

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            }

            if (item.Done)
            {
                cell.Accessory = UITableViewCellAccessory.Checkmark;
            }
            cell.TextLabel.Text = item.Name;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _tasks.Count;
        }
    }
}
