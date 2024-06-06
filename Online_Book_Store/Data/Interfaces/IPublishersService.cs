using Online_Book_Store.Models;

namespace Online_Book_Store.Data.Interfaces
{
    public interface IPublishersService
    {
        Task<IEnumerable<Publisher>> GetAllAsync();
        Task<Publisher> GetByIdAsync(int id);

        Task AddAsync(Publisher publisher);

        Task UpdateAsync(int id, Publisher publisher);

        Task DeleteAsync(int id);
    }
}
