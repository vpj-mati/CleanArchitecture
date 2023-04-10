﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProcesoAutonomo.ServiceA.Domain.Entities;
using ProcesoAutonomo.ServiceA.Domain.Enums;

namespace ProcesoAutonomo.ServiceA.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List From Service A",
                Items =
                {
                    new TodoItem { Title = "Make a todo list 📃", Priority = PriorityLevel.High },
                    new TodoItem { Title = "Check off the first item ✅", Priority = PriorityLevel.Low },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯", Priority = PriorityLevel.Medium},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆", Priority = PriorityLevel.None },
                }
            });

            await _context.SaveChangesAsync();
        }
    }
}
