using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class ExpenseService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ExpenseService> _logger;

        public ExpenseService(ApplicationDbContext db,
            ILogger<ExpenseService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<Expense>> GetAllExpensesAsync(string userId)
        {
            return await _db.Expenses.Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<Expense> GetExpenseAsync(Guid expenseId)
        {
            return await _db.Expenses.FirstOrDefaultAsync(e => e.Id == expenseId);
        }

        public async Task CreateExpenseAsync(Expense expense)
        {
            _db.Expenses.Add(expense);
            await _db.SaveChangesAsync();

            _logger.LogInformation("A new expense has been created.");
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            _db.Entry(expense).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();

                _logger.LogInformation("An expense has been updated.");
            }
            catch (DbUpdateConcurrencyException e)
            {
                _logger.LogError($"An error has occurred whilst trying to update an expense: {e}");
            }
        }

        public async Task DeleteAllPersonsExpenses(Guid personId)
        {
            var expeneses = await _db.Expenses.Where(p => p.PersonId == personId).ToListAsync();

            if (expeneses.Count is 0)
            {
                return;
            }

            _db.Expenses.RemoveRange(expeneses);
            await _db.SaveChangesAsync();

            _logger.LogInformation("All expenses for a person have been deleted.");
        }

        public async Task DeleteExpense(Guid id)
        {
            var expense = await _db.Expenses.FindAsync(id);

            if (expense is null)
            {
                _logger.LogError("Error deleting expense: Expense not found.");
                return;
            }

            _db.Expenses.Remove(expense);
            await _db.SaveChangesAsync();

            _logger.LogInformation("An expense has been deleted.");
        }
    }
}
