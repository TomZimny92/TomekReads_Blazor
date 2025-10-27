using Microsoft.Data.Sqlite;
using TomekReads.Data;
using TomekReads.Models;

namespace TomekReads.Services
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _context;

        public BookService(BookDbContext context)
        {
            _context = context;
        }

        public async static Task<IEnumerable<Book>> GetAllAsync()
        {
            // open the database
            // query the database
            // format the results
            // return list of books
            return await _context.Books.ToList();
        }

        public async static Task<Book?> GetBookAsync(int id)
        {
            // open the database
            // query the database using the id
            // format the result
            // if no result, throw exception?
            // otherwise, return the result
            var newBook = new Book{ Title="test"};
            return newBook;
        }

        public async static Task<Book> AddBookAsync(Book book)
        {
            await _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public static void AddBooks(IEnumerable<Book> books)
        {

        }

        public static void UpdateBook(Book book)
        {
            
        }
    }
}
