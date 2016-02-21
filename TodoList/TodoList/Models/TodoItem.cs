using SQLite;

namespace TodoList.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }

        public void Complete()
        {
            Done = true;
        }

        public void MarkAsIncomplete()
        {
            Done = false;
        }
    }
}
