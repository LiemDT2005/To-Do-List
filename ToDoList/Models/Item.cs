namespace TodoList.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Text { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
