using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using TomekReads.Data;
using TomekReads.Data.Models;

namespace TomekReads.Data.Services
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _bookDbContext;

        public BookService(BookDbContext context)
        {
            _bookDbContext = context;
        }

        public async Task<IEnumerable<Book>?> GetAllAsync()
        {
            try
            {
                return await _bookDbContext.Books.ToListAsync<Book>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return null;
            }
        }

        public async Task<Book?> GetBookAsync(int id)
        {
            try {
                var book = await _bookDbContext.Books.SingleOrDefaultAsync((b) => b.Id == id);
                if (book == default)
                {
                    return null;
                }
                return book;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return null;
            }
        }

        public async Task<Book?> AddBookAsync(Book book)
        {
            try
            {
                await _bookDbContext.Books.AddAsync(book);
                var newBook = await _bookDbContext.Books.FindAsync(book.Id);
                if (newBook == null)
                {
                    return null;
                }
                await _bookDbContext.SaveChangesAsync();
                return newBook;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message} \n {ex.StackTrace}");
                return null;
            }
        }

        public async Task<IEnumerable<Book>> AddBooksAsync(IEnumerable<Book> books)
        {
            var addedBooks = new List<Book>();
            try
            {
                _bookDbContext.Books.AddRange(books);

                foreach (var book in books)
                {
                    var newBook = await _bookDbContext.Books.FirstOrDefaultAsync((b) => b.Id == book.Id);
                    if (newBook != null)
                    {
                        addedBooks.Add(newBook);
                    }
                }
                await _bookDbContext.SaveChangesAsync();
                return addedBooks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message} \n {ex.StackTrace}");
                
                return addedBooks;

            }
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {
            try
            {
                await _bookDbContext.Books
                    .Where(b => b.Id == book.Id)
                    .ExecuteUpdateAsync(b => b.SetProperty(bb => bb.Title, book.Title)
                        .SetProperty(bb => bb.Review, book.Review)
                        .SetProperty(bb => bb.Rating, book.Rating));

                await _bookDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            try
            {
                await _bookDbContext.Books
                    .Where((b) => b.Id == id)
                    .ExecuteDeleteAsync();

                await _bookDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteBooksAsync(IEnumerable<int> ids)
        {
            try
            {
                var booksToDelete = new List<Book>();
                foreach (int id in ids)
                {
                    var book = await _bookDbContext.Books.FindAsync(id);
                    if (book != null)
                    {
                        booksToDelete.Add(book);
                    }
                }
                _bookDbContext.Books
                    .RemoveRange(booksToDelete);
                await _bookDbContext.SaveChangesAsync();
                return true;
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"ex.Message: {ex.Message}");
                return false;
            }
        }
    }
}
