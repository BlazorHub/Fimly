using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class CurrencyService
    {
        private readonly ApplicationDbContext _db;

        public CurrencyService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            return await _db.Currencies.ToListAsync();
        }
    }
}
