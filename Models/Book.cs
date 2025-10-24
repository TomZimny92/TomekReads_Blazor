namespace TomekReads.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Rating { get; set; }
        public string? Review { get; set; }
    }
}
