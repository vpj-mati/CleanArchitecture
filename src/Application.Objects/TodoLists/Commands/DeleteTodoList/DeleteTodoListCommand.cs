using MediatR;

namespace ProcesoAutonomo.ServiceA.Application.Objects.TodoLists.Commands.DeleteTodoList;

public record DeleteTodoListCommand(int Id) : IRequest;