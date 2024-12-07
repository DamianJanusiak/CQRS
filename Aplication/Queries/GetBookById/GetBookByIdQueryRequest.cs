using MediatR;

namespace Aplication.Queries.GetBooks
{
    public record GetBookByIdQueryRequest(Guid Id) : IRequest<GetBookByIdQueryResponse>;
}
