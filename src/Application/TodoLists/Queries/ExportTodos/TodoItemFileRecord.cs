using ProcesoAutonomo.ServiceA.Application.Common.Mappings;
using ProcesoAutonomo.ServiceA.Domain.Entities;

namespace ProcesoAutonomo.ServiceA.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; init; }

    public bool Done { get; init; }
}
