using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class ExpenseService
    {
        private readonly ILogger<ExpenseService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ExpenseService(ILogger<ExpenseService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<List<Expense>> GetAllExpensesAsync(string userId)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                return await context.Expenses.Where(u => u.UserId == userId).ToListAsync();
            }
        }

        public async Task<Expense> GetExpenseAsync(Guid expenseId)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                return await context.Expenses.FirstOrDefaultAsync(e => e.Id == expenseId);
            }
        }

        public async Task<List<Expense>> GetPersonsExpensesByMonth(Guid personId, string month)
        {
            var filterDate = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture);

            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                return await context.Expenses
                    .Where(e => e.PersonId == personId && e.DateAdded.Month == filterDate.Month && e.DateAdded.Year == filterDate.Year)
                    .Include(x => x.ExpenseType)
                    .ToListAsync();
            }
        }

        public async Task CreateExpenseAsync(Expense expense)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.Expenses.Add(expense);
                await context.SaveChangesAsync();

                _logger.LogInformation("A new expense has been created.");
            }
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.Entry(expense).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();

                    _logger.LogInformation("An expense has been updated.");
                }
                catch (DbUpdateConcurrencyException e)
                {
                    _logger.LogError($"An error has occurred whilst trying to update an expense: {e}");
                }
            }
        }

        public async Task DeleteAllPersonsExpenses(Guid personId)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                var expeneses = await context.Expenses.Where(p => p.PersonId == personId).ToListAsync();

                if (expeneses.Count is 0)
                {
                    return;
                }

                context.Expenses.RemoveRange(expeneses);
                await context.SaveChangesAsync();

                _logger.LogInformation("All expenses for a person have been deleted.");
            }
        }

        public async Task DeleteExpense(Guid id)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                var expense = await context.Expenses.FindAsync(id);

                if (expense is null)
                {
                    _logger.LogError("Error deleting expense: Expense not found.");
                    return;
                }

                context.Expenses.Remove(expense);
                await context.SaveChangesAsync();

                _logger.LogInformation("An expense has been deleted.");
            }
        }
    }
}
