using MediatR;
using ProcesoAutonomo.ServiceA.Application.Objects.Common.Models;

namespace ProcesoAutonomo.ServiceA.Application.Objects.TodoItems.Queries.GetTodoItemsWithPagination;

public record GetTodoItemsWithPaginationQuery : IRequest<PaginatedList<TodoItemBriefDto>>
{
    public int ListId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}