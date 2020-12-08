using FluentValidation;

namespace Application.Articles.Commands.Create
{
  public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
  {
    public CreateArticleCommandValidator()
    {
      RuleFor(s => s.Title)
        .MaximumLength(50)
        .MinimumLength(1)
        .NotEmpty();
    }
  }
}