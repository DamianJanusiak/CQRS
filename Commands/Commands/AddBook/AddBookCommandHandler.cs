using Aplication.Repositories;
using Commands.Commands.DeleteBook;
using Domain;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

namespace Commands.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommandRequest>
    {
        private readonly IBooksRepository _booksRepository;

        public AddBookCommandHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public Task<List<Book>> Books { get; private set; }

        [Function("AddBook")]
        [OpenApiOperation("AddBook", "Books")]
        [OpenApiRequestBody("application/json", typeof(AddBookCommandRequest))]
        public async Task Handle([HttpTrigger(AuthorizationLevel.Anonymous, "post")] AddBookCommandRequest request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Author = request.Author,
                Content = request.Content,
                Description = request.Description,
                CreateDate = DateTime.UtcNow,
                BookPages = request.PageNumber,
                Id = Guid.NewGuid(),
                Title = request.Title,
            };
            await _booksRepository.AddBook(book);
        }
    }
}
