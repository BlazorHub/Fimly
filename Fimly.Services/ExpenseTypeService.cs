using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class ExpenseTypeService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ExpenseTypeService> _logger;

        public ExpenseTypeService(IServiceProvider serviceProvider,
            ILogger<ExpenseTypeService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task<List<ExpenseType>> GetExpenseTypesAsync()
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                return await context.ExpenseTypes.OrderBy(e => e.Name).ToListAsync();
            }
        }

        public async Task SeedDefaultExpenseTypesAsync(string userId)
        {
            List<ExpenseType> seedExpenseTypes = new List<ExpenseType>
            {
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "Bills & Services", Icon = "fas fa-money-bill-wave" },
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "Entertainment", Icon = "fas fa-glass-cheers" },
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "Transport", Icon = "fas fa-bus-alt" },
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "Groceries", Icon = "fas fa-utensils" },
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "Home", Icon = "fas fa-home" },
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "Eating Out", Icon = "fas fa-pizza-slice" },
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "Family", Icon = "fas fa-users" },
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "General", Icon = "fas fa-money-check" },
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "Lifestyle", Icon = "fas fa-heartbeat" },
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "Shopping", Icon = "fas fa-shopping-basket" },
                new ExpenseType { Id = Guid.NewGuid(), UserId = userId, Name = "Holidays", Icon = "fas fa-plane" }
            };

            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.ExpenseTypes.AddRange(seedExpenseTypes);
                await context.SaveChangesAsync();

                _logger.LogInformation("Default expense types seeded.");
            }
        }
    }
}
