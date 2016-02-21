using System;
using System.IO;
using TodoList.DataAccess;
using TodoList.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(IosDbPathProvider))]
namespace TodoList.iOS
{
    class IosDbPathProvider : ISqLiteDbPathProvider
    {
        public string GetDbPath()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            return path;
        }
    }
}