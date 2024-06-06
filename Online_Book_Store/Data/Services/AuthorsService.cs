using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data.Interfaces;
using Online_Book_Store.Models;

namespace Online_Book_Store.Data.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var result = await _context.Authors.ToListAsync();
            return result;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task AddAsync(Author author)
        {
            await _context.Authors.AddAsync(author);

            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, Author author)
        {
            _context.Update(author);

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);

            _context.Authors.Remove(result);

            await _context.SaveChangesAsync();
        }

              
        
    }
}
