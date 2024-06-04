using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data;

namespace Online_Book_Store.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorsController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> IndexAsync()
        {
            var AuthorsData = await _context.Authors.ToListAsync();
            return View(AuthorsData);
            
        }
    }
}
