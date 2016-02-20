using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Widget;
using TodoList.Models;

namespace TodoList.Droid
{
    /// <summary>
    /// Adapter that presents Tasks in a row-view
    /// </summary>
    public class TodoItemListAdapter : BaseAdapter<TodoItem>
    {
        readonly Activity _context;
        readonly IList<TodoItem> _tasks;

        public TodoItemListAdapter(Activity context, IList<TodoItem> tasks)
        {
            _context = context;
            _tasks = tasks;
        }

        public override TodoItem this[int position] => _tasks[position];

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count => _tasks.Count;

        public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        {
            //get item
            var item = _tasks[position];
            
            //inflate view
            var view = (convertView ??
                _context.LayoutInflater.Inflate(
                    Android.Resource.Layout.SimpleListItemChecked,
                    parent,
                    false)) as CheckedTextView;
            if (view == null)
            {
                throw new Exception("cannot resolve a view");
            }

            view.SetText(item.Name, TextView.BufferType.Normal);
            view.Checked = item.Done;
            
            //return view
            return view;
        }
    }
}