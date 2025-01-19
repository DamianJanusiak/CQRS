using FluentValidation;

namespace Commands.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommandRequest>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
