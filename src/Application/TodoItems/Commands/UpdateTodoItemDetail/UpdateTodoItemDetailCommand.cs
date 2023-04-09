using AutoMapper;
using MediatR;
using ProcesoAutonomo.ServiceA.Application.Common.Exceptions;
using ProcesoAutonomo.ServiceA.Application.Common.Interfaces;
using ProcesoAutonomo.ServiceA.Application.Objects.TodoItems.Commands.UpdateTodoItemDetail;
using ProcesoAutonomo.ServiceA.Domain.Entities;

namespace ProcesoAutonomo.ServiceA.Application.TodoItems.Commands.UpdateTodoItemDetail;

public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateTodoItemDetailCommandHandler(IApplicationDbContext context, 
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken) ?? throw new NotFoundException(nameof(TodoItem), request.Id);
        
        //entity.ListId = request.ListId;
        //entity.Priority = request.Priority;
        //entity.Note = request.Note;

        entity = _mapper.Map<TodoItem>(request);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
