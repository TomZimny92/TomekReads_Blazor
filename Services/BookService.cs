using TomekReads.Models;

namespace TomekReads.Services
{
    public class BookService
    {
        public static async List<Book> GetAll()
        {
            // open the database
            // query the database
            // format the results
            // return list of books
        }

        public static async Book? GetBook(int id)
        {
            // open the database
            // query the database using the id
            // format the result
            // if no result, throw exception?
            // otherwise, return the result
        }

        public static void AddBook(Book book)
        {

        }
    }
}
