using Fimly.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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

        public async Task DeleteAllPersonsExpenses(Guid personId)
        {
            var expeneses = await _db.Expenses.Where(p => p.PersonId == personId || p.IsShared == true).ToListAsync();

            _db.Expenses.RemoveRange(expeneses);
            await _db.SaveChangesAsync();

            _logger.LogInformation("All expenses for a person have been deleted.");
        }
    }
}
