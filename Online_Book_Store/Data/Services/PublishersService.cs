using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data.Interfaces;
using Online_Book_Store.Models;

namespace Online_Book_Store.Data.Services
{
    public class PublishersService : IPublishersService
    {
        private readonly AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            var result = await _context.Publishers.ToListAsync();
            return result;
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            var result = await _context.Publishers.FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task AddAsync(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);

            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, Publisher publisher)
        {
            _context.Update(publisher);

            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Publishers.FirstOrDefaultAsync(a => a.Id == id);

            _context.Publishers.Remove(result);

            await _context.SaveChangesAsync();
        }

       
    }
}
