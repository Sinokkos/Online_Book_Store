using Online_Book_Store.Models;

namespace Online_Book_Store.Data.Interfaces
{
    public interface IBooksService
    {
        Task <IEnumerable<Book>> GetAllAsync ();
        Task<Book> GetByIdAsync (int id);

        Task AddAsync (Book book);

        Task UpdateAsync (int id, Book book);

        Task DeleteAsync (int id);
    }
}
