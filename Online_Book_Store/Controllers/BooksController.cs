using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data;
using Online_Book_Store.Data.Interfaces;

namespace Online_Book_Store.Controllers
{
    public class BooksController : Controller 
    { 
        private readonly IBooksService _service;

        public BooksController(IBooksService service)
        {
           _service = service;

         }


        public async Task<IActionResult> Index()
        {
            var BooksData = await _service.GetAllAsync();
            return View(BooksData);
        }
    }
}
