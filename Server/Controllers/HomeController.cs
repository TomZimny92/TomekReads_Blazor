using Microsoft.AspNetCore.Mvc;
using TomekReads.Data;
using TomekReads.Data.Services;

namespace TomekReads.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookDbContext? _bookDbContext;
        public IActionResult Home()
        {
            if (_bookDbContext != null)
            {
                var bs = new BookService(_bookDbContext);
                var books = bs.GetAllAsync();
                return View(books);
            }
            return View();
            
        }
    }
}
