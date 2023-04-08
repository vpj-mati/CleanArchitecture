using AutoMapper;
using ProcesoAutonomo.ServiceA.Application.Objects.TodoItems.Queries.GetTodoItemsWithPagination;
using ProcesoAutonomo.ServiceA.Domain.Entities;

namespace ProcesoAutonomo.ServiceA.Application.TodoItems.Queries.GetTodoItemsWithPagination;
internal class TodoItemMapping : Profile
{
    public TodoItemMapping()
    {
        CreateMap<TodoItem, TodoItemBriefDto>();
    }
}
