using Aplication.Repositories;
using Domain;
using MediatR;

namespace Aplication.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQueryRequest, GetBooksQueryResponse>
    {
        private readonly IBooksRepository _booksRepository;

        public GetBooksQueryHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public Task<List<Book>> Books { get; private set; }

        public async Task<GetBooksQueryResponse> Handle(GetBooksQueryRequest request, CancellationToken cancellationToken)
        {
            var books = await _booksRepository.GetBooks(request.PageSize);

            return new GetBooksQueryResponse
            {
                Books = books
            };

        }
    }
}
