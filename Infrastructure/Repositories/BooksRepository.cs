using Aplication.Repositories;
using CQRS.Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly CQRSContext _context;

        public BooksRepository(CQRSContext context)
        {
            _context = context;
        }

        public async Task AddBook(Book book)
        {
            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public Task<List<Book>> GetBooks(string? author, int? pageSize)
        {
            var query = _context.Book;

            if (author != null)
            {
                query.Where(x => x.Author == author);
            }

            if (pageSize != null)
            {
                query.Take(pageSize ?? 10);
            }

            return query.ToListAsync();
        }

        public Task<Book> GetBookyId(Guid Id)
        {
            return _context.Book.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Book> UpdateBook(Guid id, string title, string author, string description, int pageNumber)
        {
            var book = await GetBookyId(id);

            book.Title = title;
            book.Author = author;
            book.Description = description;
            book.BookPages = pageNumber;

            _context.Update(book);
            await _context.SaveChangesAsync();

            return book;
        }
    }
}
