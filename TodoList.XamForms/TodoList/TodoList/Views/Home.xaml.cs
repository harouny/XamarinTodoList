using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.Models;
using TodoList.ViewModels;
using Xamarin.Forms;

namespace TodoList.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        
        private void SwitchCell_OnOnChanged(object sender, ToggledEventArgs e)
        {
             ((HomeViewModel)BindingContext).SignalTodoItemChangedAsync((TodoItem)((SwitchCell)sender).BindingContext);
        }
    }
}
