using Online_Book_Store.Models;

namespace Online_Book_Store.Data.Interfaces
{
    public interface IAuthorsService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);

        Task AddAsync(Author author);

        Task UpdateAsync(int id, Author author);

        Task DeleteAsync(int id);
    }
}
