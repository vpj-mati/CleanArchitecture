using ProcesoAutonomo.ServiceA.Application.Common.Mappings;
using ProcesoAutonomo.ServiceA.Domain.Entities;

namespace ProcesoAutonomo.ServiceA.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
{
    public int Id { get; init; }

    public string? Title { get; init; }
}
