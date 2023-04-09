using MediatR;

namespace ProcesoAutonomo.ServiceA.Application.Objects.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id) : IRequest;