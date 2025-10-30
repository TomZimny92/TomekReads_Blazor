using Microsoft.AspNetCore.Mvc;
using TomekReads.Data;
using TomekReads.Services;

namespace TomekReads.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookDbContext _bookDbContext;
        public IActionResult Home()
        {
            var bs = new BookService(_bookDbContext);
            var books = bs.GetAllAsync();
            return View(books);
        }
    }
}
