using Microsoft.AspNetCore.Mvc;
using Online_Book_Store.Data;
using Online_Book_Store.Data.Interfaces;
using Online_Book_Store.Models;

namespace Online_Book_Store.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublishersService _service;

        public PublishersController(IPublishersService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var PublishersData= _service.GetAllAsync();
            return View(PublishersData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name,Author, ImageURL")] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(publisher);
            }

            await _service.AddAsync(publisher);

            return RedirectToAction(nameof(Index));
        }
    }
}
