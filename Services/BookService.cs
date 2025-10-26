using TomekReads.Models;

namespace TomekReads.Services
{
    public class BookService
    {
        public static List<Book> GetAll()
        {
            // open the database
            // query the database
            // format the results
            // return list of books
            var newList = new List<Book>();
            return newList;
        }

        public static Book? GetBook(int id)
        {
            // open the database
            // query the database using the id
            // format the result
            // if no result, throw exception?
            // otherwise, return the result
            var newBook = new Book{ Title="test"};
            return newBook;
        }

        public static void AddBook(Book book)
        {

        }

        public static void AddBooks(IEnumerable<Book> books)
        {

        }

        public static void UpdateBook(Book book)
        {
            
        }
    }
}
