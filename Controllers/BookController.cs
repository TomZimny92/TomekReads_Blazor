using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TomekReads.Services;
using TomekReads.Models;

namespace TomekReads.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Book>>> GetAllBooksAsync()
        {
            try
            {
                var books = await _bookService.GetAllAsync();
                if (books == null)
                {
                    return NotFound();
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> GetBookAsync(int id)
        {
            try
            {
                var book = await _bookService.GetBookAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBookAsync(Book book)
        {
            // validate book parameter
            //var isValid = await _validationService.Validate(book);
            //if (isValid) ....

            try
            {
                var newBook = await _bookService.AddBookAsync(book);
                if (newBook == null)
                {
                    return BadRequest();
                }

                return CreatedAtAction(nameof(GetBookAsync), new { id = newBook.Id }, newBook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBooksAsync(IEnumerable<Book> books)
        {
            // validate book parameter
            //var isValid = await _validationService.Validate(books);
            //if (isValid) ....
            try
            {
                var newBooks = await _bookService.AddBooksAsync(books);
                if (newBooks == null)
                {
                    return BadRequest();
                }
                return Ok(newBooks);
                //return CreatedAtAction(nameof(GetAllBooksAsync), books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBookAsync(int id, Book book)
        {
            try
            {
                if (id != book.Id)
                {
                    return BadRequest("parameter 'id' does not match 'book.Id'");
                }
                var existingBook = await _bookService.GetBookAsync(id);
                if (existingBook == null)
                {
                    return NotFound();
                }
                var isUpdated = await _bookService.UpdateBook(book);
                return Ok(isUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveBookAsync(int id)
        {
            try
            {
                var existingBook = await _bookService.GetBookAsync(id);
                if (existingBook == null)
                {
                    return NotFound();
                }
                var isDeleted = await _bookService.DeleteBookAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }                
        }
    }
}
