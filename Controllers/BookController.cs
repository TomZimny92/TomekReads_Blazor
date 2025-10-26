using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomekReads.Services;
using TomekReads.Models;

namespace TomekReads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        public BookController()
        {
            var arrtest = new Book[10];
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return BookService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = BookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            // validate book parameter
            
            BookService.AddBook(book);
            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPost]
        public IActionResult CreateBooks(List<Book> books)
        {
            // validate books parameter

            BookService.AddBooks(books);
            return CreatedAtAction(nameof(GetAll), books);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            var existingBook = BookService.GetBook(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            BookService.UpdateBook(book);
            return Ok();
        }
    }
}
