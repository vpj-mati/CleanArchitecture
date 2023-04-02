﻿using ProcesoAutonomo.ServiceA.Application.Common.Exceptions;
using ProcesoAutonomo.ServiceA.Application.Common.Interfaces;
using ProcesoAutonomo.ServiceA.Domain.Entities;
using ProcesoAutonomo.ServiceA.Domain.Events;
using MediatR;

namespace ProcesoAutonomo.ServiceA.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id) : IRequest;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken) ?? throw new NotFoundException(nameof(TodoItem), request.Id);
        
        _context.TodoItems.Remove(entity);

        entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
