using Aplication.Repositories;
using Commands.Commands.UpdateBookDetails;
using Domain;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using System.Net;

namespace Commands.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommandRequest>
    {
        private readonly IBooksRepository _booksRepository;

        public DeleteBookCommandHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }


        [Function("DeleteBook")]
        [OpenApiOperation("DeleteBook", "Books")]
        [OpenApiRequestBody("application/json", typeof(DeleteBookCommandRequest))]
        public async Task Handle([HttpTrigger(AuthorizationLevel.Anonymous, "delete")] DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            await _booksRepository.DeleteBook(request.Id);
        }
    }
}
