using MediatR;
using ProcesoAutonomo.ServiceA.Application.Common.Exceptions;
using ProcesoAutonomo.ServiceA.Application.Common.Interfaces;
using ProcesoAutonomo.ServiceA.Application.Objects.TodoLists.Commands.UpdateTodoList;
using ProcesoAutonomo.ServiceA.Domain.Entities;

namespace ProcesoAutonomo.ServiceA.Application.TodoLists.Commands.UpdateTodoList;

public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoLists
            .FindAsync(new object[] { request.Id }, cancellationToken) ?? throw new NotFoundException(nameof(TodoList), request.Id);
        
        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
