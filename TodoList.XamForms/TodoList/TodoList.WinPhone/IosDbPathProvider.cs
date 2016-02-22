using System.IO;
using Windows.Storage;
using TodoList.DataAccess;
using TodoList.WinPhone;
using Xamarin.Forms;

[assembly: Dependency(typeof(IosDbPathProvider))]
namespace TodoList.WinPhone
{
    class IosDbPathProvider : ISqLiteDbPathProvider
    {
        public string GetDbPath()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            return path;
        }
    }
}