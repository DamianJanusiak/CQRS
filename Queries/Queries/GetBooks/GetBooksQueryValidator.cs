using FluentValidation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Queries.GetBooks
{
    public class GetBooksQueryValidator : AbstractValidator<GetBooksQueryRequest>
    {
        public GetBooksQueryValidator()
        {
            When(x => x.PageSize is not null, () =>
            {
                RuleFor(x => x.PageSize).GreaterThan(10).LessThan(100);
            });
        }
    }
}
