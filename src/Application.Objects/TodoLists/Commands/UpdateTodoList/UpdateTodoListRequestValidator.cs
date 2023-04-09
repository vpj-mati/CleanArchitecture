using FluentValidation;

namespace ProcesoAutonomo.ServiceA.Application.Objects.TodoLists.Commands.UpdateTodoList;

public class UpdateTodoListRequestValidator
    : AbstractValidator<UpdateTodoListCommand>
{
    public UpdateTodoListRequestValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
    }
}
