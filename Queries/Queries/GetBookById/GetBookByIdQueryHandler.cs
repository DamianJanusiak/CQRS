using Aplication.Repositories;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System.Net;

namespace Queries.Queries.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQueryRequest, GetBookByIdQueryResponse>
    {
        private readonly IBooksRepository _booksRepository;

        public GetBookByIdQueryHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [Function("GetBookById")]
        [OpenApiOperation("GetBookById","Books")]
        [OpenApiRequestBody("application/json", typeof(GetBookByIdQueryRequest))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(GetBookByIdQueryResponse))]
        public async Task<GetBookByIdQueryResponse> Handle([HttpTrigger(AuthorizationLevel.Anonymous, "get")] GetBookByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.GetBookyId(request.Id);

            return new GetBookByIdQueryResponse
            {
                Book = book,
            };

        }
    }
}
