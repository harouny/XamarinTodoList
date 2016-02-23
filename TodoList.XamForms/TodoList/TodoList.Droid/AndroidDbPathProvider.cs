using System.IO;
using TodoList.DataAccess;
using TodoList.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDbPathProvider))]
namespace TodoList.Droid
{
    class AndroidDbPathProvider : ISqLiteDbPathProvider
    {
        public string GetDbPath()
        {
            var sqliteFilename = "TodoItemDB4.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}