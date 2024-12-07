using Aplication.Repositories;
using MediatR;

namespace Aplication.Queries.GetBooks
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQueryRequest, GetBookByIdQueryResponse>
    {
        private readonly IBooksRepository _booksRepository;

        public GetBookByIdQueryHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<GetBookByIdQueryResponse> Handle(GetBookByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.GetBookyId(request.Id);

            return new GetBookByIdQueryResponse
            {
                Book = book,
            };

        }
    }
}
