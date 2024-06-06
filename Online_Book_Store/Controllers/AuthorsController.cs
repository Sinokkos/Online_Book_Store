using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data;
using Online_Book_Store.Data.Interfaces;
using Online_Book_Store.Models;

namespace Online_Book_Store.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService _service;

        public AuthorsController(IAuthorsService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var AuthorsData = await _service.GetAllAsync();
            return View(AuthorsData);
        }

        // Create 
        // Get:

        public IActionResult Create()
        {
            return View();
        }


        // Post
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name,Author, ImageURL")] Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            await _service.AddAsync(author);

            return RedirectToAction(nameof(Index));

        }

        // Details
        // Get:
        public async Task<IActionResult> Details(int id)
        {
            //var actorDetails = _service.GetById(id);
            // (23)
            var authorDetails = await _service.GetByIdAsync(id);

            if (authorDetails == null) { return View("NotFound"); }

            return View(authorDetails);
        }
    }
}
