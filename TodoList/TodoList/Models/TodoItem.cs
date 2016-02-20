namespace TodoList.Models
{
    public class TodoItem
    {
        public string Id { get; set; }
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
