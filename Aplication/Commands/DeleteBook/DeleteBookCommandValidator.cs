using FluentValidation;

namespace Aplication.Queries.GetBooks
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommandRequest>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
        }
    }
}
