using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class CurrencyService
    {
        private readonly IServiceProvider _serviceProvider;

        public CurrencyService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<List<Currency>> GetCurrenciesAsync()
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                return await context.Currencies.ToListAsync();
            }
        }
    }
}
