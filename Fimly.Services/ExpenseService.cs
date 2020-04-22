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

        public async Task CreateExpenseAsync(Expense expense)
        {
            _db.Expenses.Add(expense);
            await _db.SaveChangesAsync();

            _logger.LogInformation("A new expense has been created.");
        }

        public async Task DeleteAllPersonsExpenses(Guid personId)
        {
            var expeneses = await _db.Expenses.Where(p => p.PersonId == personId).ToListAsync();

            _db.Expenses.RemoveRange(expeneses);
            await _db.SaveChangesAsync();

            _logger.LogInformation("All expenses for a person have been deleted.");
        }
    }
}
