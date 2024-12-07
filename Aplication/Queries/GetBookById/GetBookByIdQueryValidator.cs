using FluentValidation;

namespace Aplication.Queries.GetBooks
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQueryRequest>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(x=>x.Id).NotEqual(Guid.Empty);
        }
    }
}
