using Aplication.Repositories;
using Domain;
using MediatR;

namespace Aplication.Queries.GetBooks
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookDetailsCommandRequest>
    {
        private readonly IBooksRepository _booksRepository;

        public UpdateBookCommandHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task Handle(UpdateBookDetailsCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.UpdateBook(request.Id, request.Title, request.Author, request.Description,request.Pagenumber);
        }
    }
}
