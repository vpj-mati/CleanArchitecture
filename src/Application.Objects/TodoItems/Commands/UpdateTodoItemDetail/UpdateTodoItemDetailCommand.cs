using MediatR;
using ProcesoAutonomo.ServiceA.Application.Objects.Enums;

namespace ProcesoAutonomo.ServiceA.Application.Objects.TodoItems.Commands.UpdateTodoItemDetail;

public record UpdateTodoItemDetailCommand : IRequest
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public PriorityLevel Priority { get; set; }

    public string? Note { get; set; }
}