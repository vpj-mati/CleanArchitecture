using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProcesoAutonomo.ServiceA.Application.Common.Interfaces;
using ProcesoAutonomo.ServiceA.Application.Objects.TodoLists.Commands.UpdateTodoList;

namespace ProcesoAutonomo.ServiceA.Application.TodoLists.Commands.UpdateTodoList;

public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoListCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v).SetValidator(new UpdateTodoListRequestValidator());

        RuleFor(v => v.Title)
            .MustAsync(BeUniqueTitle)
            .WithMessage("The specified title already exists.");
    }

    public async Task<bool> BeUniqueTitle(UpdateTodoListCommand model, string? title, CancellationToken cancellationToken)
    {
        return await _context.TodoLists
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
