﻿using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoLists.Commands.DeleteTodoList;

public record DeleteTodoListCommand(int Id) : IRequest;

public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoLists
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(nameof(TodoList), request.Id);
        _context.TodoLists.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
