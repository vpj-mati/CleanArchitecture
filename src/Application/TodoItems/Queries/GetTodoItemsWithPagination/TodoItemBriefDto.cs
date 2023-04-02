using ProcesoAutonomo.ServiceA.Application.Common.Mappings;
using ProcesoAutonomo.ServiceA.Domain.Entities;

namespace ProcesoAutonomo.ServiceA.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}
