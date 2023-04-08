using MediatR;

namespace ProcesoAutonomo.ServiceA.Application.Objects.TodoLists.Commands.CreateTodoList;

public record CreateTodoListCommand : IRequest<int>
{
    public string? Title { get; set; }
}

