using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class ExpenseTypeService
    {
        private readonly ApplicationDbContext _db;

        public ExpenseTypeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ExpenseType>> GetExpenseTypesAsync()
        {
            return await _db.ExpenseTypes.OrderBy(e => e.Name).ToListAsync();
        }
    }
}
