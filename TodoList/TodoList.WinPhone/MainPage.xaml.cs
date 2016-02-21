using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TodoList.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace TodoList.WinPhone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ITodosService _todosService = new InMemoryTodosService();

        public MainPage()
        {
            InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            listView.ItemsSource = await _todosService.GetTodoItemsAsync();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _todosService.AddTodoItemAsync(new TodoItem()
            {
                Name = TodoText.Text
            });
            listView.ItemsSource = null;
            listView.ItemsSource = await _todosService.GetTodoItemsAsync();
        }
    }
}
