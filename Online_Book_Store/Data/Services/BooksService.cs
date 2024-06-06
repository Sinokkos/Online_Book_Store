using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data.Interfaces;
using Online_Book_Store.Models;
using Online_Book_Store.ViewModel;

namespace Online_Book_Store.Data.Services
{
    public class BooksService : IBooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var result = await _context.Books.ToListAsync();
            return result;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var result = await _context.Books.FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, Book book)
        {
            _context.Update(book);

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Books.FirstOrDefaultAsync(a => a.Id == id);

            _context.Books.Remove(result);

            await _context.SaveChangesAsync();
        }

        public async Task<NewBookDropdownsVM> GetNewBookDropdownsValues()
        {
            // Create ekranında bulunacak dropdownlar için listeler oluşturacak...

            var response = new NewBookDropdownsVM()
            {
                Authors = await _context.Authors.OrderBy(n => n.Name).ToListAsync(),
                Publisher = await _context.Publishers.OrderBy(n => n.Name).ToListAsync(),

            };

            return response;
        }

    }
}