using FluentAssertions;
using NUnit.Framework;
using ProcesoAutonomo.ServiceA.Application.Common.Exceptions;
using ProcesoAutonomo.ServiceA.Application.Objects.TodoItems.Commands.CreateTodoItem;
using ProcesoAutonomo.ServiceA.Application.Objects.TodoItems.Commands.DeleteTodoItem;
using ProcesoAutonomo.ServiceA.Application.Objects.TodoLists.Commands.CreateTodoList;
using ProcesoAutonomo.ServiceA.Domain.Entities;

namespace ProcesoAutonomo.ServiceA.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
