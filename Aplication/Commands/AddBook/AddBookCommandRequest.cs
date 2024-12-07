using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Queries.GetBooks
{
    public record AddBookCommandRequest(string Title, string Description, string Author, int PageNumber, byte[] Content) : IRequest<Unit>;
}
