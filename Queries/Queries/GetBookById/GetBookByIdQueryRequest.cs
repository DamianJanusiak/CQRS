using MediatR;

namespace Queries.Queries.GetBookById
{
    public record GetBookByIdQueryRequest(Guid Id) : IRequest<GetBookByIdQueryResponse>;
}
