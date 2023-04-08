namespace ProcesoAutonomo.ServiceA.Application.Objects.TodoLists.Queries.GetTodos;

public class TodosVm
{
    public List<PriorityLevelDto> PriorityLevels { get; set; } = new();

    public List<TodoListDto> Lists { get; set; } = new();
}
