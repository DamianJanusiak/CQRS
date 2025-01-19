using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Commands.DeleteBook
{
    public record DeleteBookCommandRequest(Guid Id) : IRequest;
}
