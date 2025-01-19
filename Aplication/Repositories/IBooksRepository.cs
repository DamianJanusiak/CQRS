using Domain;

namespace Aplication.Repositories
{
    public interface IBooksRepository
    {
        Task AddBook(Book book);
        Task DeleteBook(Guid id);
        Task<List<Book>> GetBooks(int? pageSize);
        Task<Book> GetBookyId(Guid id);
        Task<Book> UpdateBook(Guid id, string title, string author, string description, int pageNumber);
    }
}
