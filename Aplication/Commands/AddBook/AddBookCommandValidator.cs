using FluentValidation;

namespace Aplication.Queries.GetBooks
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommandRequest>
    {
        public AddBookCommandValidator()
        {
            RuleFor(x=>x.Author).NotEmpty();
            RuleFor(x=>x.Title).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x => x.PageNumber).GreaterThan(10);
            RuleFor(x=>x.Content).NotEmpty();
        }
    }
}
