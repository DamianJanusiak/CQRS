using Aplication.Repositories;
using Domain;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using Queries.Queries.GetBookById;
using System.Net;

namespace Queries.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQueryRequest, GetBooksQueryResponse>
    {
        private readonly IBooksRepository _booksRepository;

        public GetBooksQueryHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public Task<List<Book>> Books { get; private set; }

        [Function("GetBooks")]
        [OpenApiOperation("GetBooks","Books")]
        [OpenApiRequestBody("application/json", typeof(GetBooksQueryRequest))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(GetBooksQueryResponse))]
        public async Task<GetBooksQueryResponse> Handle([HttpTrigger(AuthorizationLevel.Anonymous, "get")] GetBooksQueryRequest request, CancellationToken cancellationToken)
        {
            var books = await _booksRepository.GetBooks(request.PageSize);

            return new GetBooksQueryResponse
            {
                Books = books
            };

        }
    }
}
