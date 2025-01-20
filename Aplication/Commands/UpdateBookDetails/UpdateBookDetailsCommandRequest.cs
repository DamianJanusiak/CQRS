using MediatR;

namespace Aplication.Queries.GetBooks
{
    public record UpdateBookDetailsCommandRequest(Guid Id, string Title, string Author, string Description, int Pagenumber) : IRequest;
}
