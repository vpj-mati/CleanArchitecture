﻿using ProcesoAutonomo.ServiceA.Application.Common.Behaviours;
using ProcesoAutonomo.ServiceA.Application.Common.Interfaces;
using ProcesoAutonomo.ServiceA.Application.TodoItems.Commands.CreateTodoItem;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ProcesoAutonomo.ServiceA.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateTodoItemCommand>> _logger = null!;
    private Mock<ICurrentUserService> _currentUserService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateTodoItemCommand>>();
        _currentUserService = new Mock<ICurrentUserService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _currentUserService.Setup(x => x.UserId).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateTodoItemCommand>(_logger.Object, _currentUserService.Object);

        await requestLogger.Process(new CreateTodoItemCommand { ListId = 1, Title = "title" }, new CancellationToken());
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateTodoItemCommand>(_logger.Object, _currentUserService.Object);

        await requestLogger.Process(new CreateTodoItemCommand { ListId = 1, Title = "title" }, new CancellationToken());
    }
}
