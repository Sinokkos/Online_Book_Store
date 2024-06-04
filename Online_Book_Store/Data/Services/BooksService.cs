using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data.Interfaces;
using Online_Book_Store.Models;

namespace Online_Book_Store.Data.Services
{
    public class BooksService : IBooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context) 
        {  _context = context; 
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
}
