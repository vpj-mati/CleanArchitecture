using AutoMapper;
using ProcesoAutonomo.ServiceA.Application.Objects.TodoItems.Commands.UpdateTodoItemDetail;
using ProcesoAutonomo.ServiceA.Domain.Entities;

namespace ProcesoAutonomo.ServiceA.Application.TodoItems.Commands.UpdateTodoItemDetail;

internal class UpdateTodoItemDetailMapping : Profile
{
    public UpdateTodoItemDetailMapping()
    {
        CreateMap<UpdateTodoItemDetailCommand, TodoItem>();
    }
}
