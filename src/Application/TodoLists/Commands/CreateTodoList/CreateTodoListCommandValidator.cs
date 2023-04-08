using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProcesoAutonomo.ServiceA.Application.Common.Interfaces;
using ProcesoAutonomo.ServiceA.Application.Objects.TodoLists.Commands.CreateTodoList;

namespace ProcesoAutonomo.ServiceA.Application.TodoLists.Commands.CreateTodoList;

public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoListCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v).SetValidator(new CreateTodoListRequestValidator());

        RuleFor(v => v.Title)
            .MustAsync(BeUniqueTitle)
            .WithMessage("The specified title already exists.")
            .WithErrorCode("UNIQUE_TITLE");
    }

    public async Task<bool> BeUniqueTitle(string? title, CancellationToken cancellationToken)
    {
        return await _context.TodoLists
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
