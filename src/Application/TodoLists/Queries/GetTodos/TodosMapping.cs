using AutoMapper;
using ProcesoAutonomo.ServiceA.Application.Objects.TodoLists.Queries.GetTodos;
using ProcesoAutonomo.ServiceA.Domain.Entities;

namespace ProcesoAutonomo.ServiceA.Application.TodoLists.Queries.GetTodos;
internal class TodosMapping : Profile
{
    public TodosMapping()
    {
        CreateMap<TodoList, TodoListDto>();
        CreateMap<TodoItem, TodoItemDto>()
            .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
    }
}
