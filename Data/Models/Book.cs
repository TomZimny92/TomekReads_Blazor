using System.ComponentModel.DataAnnotations;

namespace TomekReads.Data.Models
{
    public class Book
    {
        [Key]
        public required string Id { get; set; }
        public required string Title { get; set; }
        public int Rating { get; set; }
        public string? Review { get; set; }
    }
}
