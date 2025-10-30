using Microsoft.EntityFrameworkCore;
using TomekReads.Data.Models;

namespace TomekReads.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        // Add a DbSet for each entity you want to map to a database table
        public DbSet<Book> Books { get; set; } = null!;
    }
}
