using ProcesoAutonomo.ServiceA.Application.TodoLists.Queries.ExportTodos;

namespace ProcesoAutonomo.ServiceA.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
