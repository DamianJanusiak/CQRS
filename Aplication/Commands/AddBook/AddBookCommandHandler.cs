using Aplication.Repositories;
using Domain;
using MediatR;

namespace Aplication.Queries.GetBooks
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommandRequest, Unit>
    {
        private readonly IBooksRepository _booksRepository;

        public AddBookCommandHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public Task<List<Book>> Books { get; private set; }

        public async Task<Unit> Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
        {
            await _booksRepository.AddBook(new Book
            {
                Author = request.Author,
                Content = request.Content,
                Description = request.Description,
                CreateDate = DateTime.UtcNow,
                BookPages = request.PageNumber,
                Id = Guid.NewGuid(),
                Title = request.Title,
            });

            return Unit.Value;

        }
    }
}
