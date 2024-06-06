using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data;
using Online_Book_Store.Data.Interfaces;
using Online_Book_Store.Models;

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

        public IActionResult Create() 
        { 
           
          return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name,Author, ImageURL")] Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            await _service.AddAsync(book);

            return RedirectToAction(nameof(Index));
        }
    }
}
