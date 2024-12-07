using FluentValidation;

namespace Aplication.Queries.GetBooks
{
    public class UpdateBookDetailsCommandValidator : AbstractValidator<UpdateBookDetailsCommandRequest>
    {
        public UpdateBookDetailsCommandValidator()
        {
            RuleFor(x=>x.Title).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}
