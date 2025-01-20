using Aplication.Repositories;
using Domain;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using System.Net;

namespace Commands.Commands.UpdateBookDetails
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookDetailsCommandRequest>
    {
        private readonly IBooksRepository _booksRepository;

        public UpdateBookCommandHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [Function("UpdateBook")]
        [OpenApiOperation("UpdateBook", "Books")]
        [OpenApiRequestBody("application/json", typeof(UpdateBookDetailsCommandRequest))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(UpdateBookDetailsCommandResponse))]
        public async Task Handle([HttpTrigger(AuthorizationLevel.Anonymous, "patch")] UpdateBookDetailsCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.UpdateBook(request.Id, request.Title, request.Author, request.Description, request.Pagenumber);
        }
    }
}
