using FluentValidation;

namespace ProcesoAutonomo.ServiceA.Application.Objects.TodoLists.Commands.CreateTodoList;

public class CreateTodoListRequestValidator
    : AbstractValidator<CreateTodoListCommand>
{
    public CreateTodoListRequestValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
    }
}
