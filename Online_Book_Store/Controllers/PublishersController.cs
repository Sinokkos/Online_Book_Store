using Microsoft.AspNetCore.Mvc;
using Online_Book_Store.Data;

namespace Online_Book_Store.Controllers
{
    public class PublishersController : Controller
    {
        private readonly AppDbContext _context;

        public PublishersController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var PublishersData= _context.Publishers.ToList();
            return View(PublishersData);
        }
    }
}
