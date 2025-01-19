using MediatR;

namespace Commands.Commands.UpdateBookDetails
{
    public record UpdateBookDetailsCommandRequest(Guid Id, string Title, string Author, string Description, int Pagenumber) : IRequest<UpdateBookDetailsCommandResponse>;
}
