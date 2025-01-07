using Aplication.Repositories;
using Domain;
using MediatR;

namespace Aplication.Queries.GetBooks
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommandRequest, Unit>
    {
        private readonly IBooksRepository _booksRepository;

        public DeleteBookCommandHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }


        public async Task<Unit> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            await _booksRepository.DeleteBook(request.Id);

            return Unit.Value;
        }
    }
}
