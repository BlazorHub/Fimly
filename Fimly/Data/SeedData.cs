using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Data
{
    public class SeedData
    {
        private readonly IServiceProvider serviceProvider;

        public SeedData(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task InitialiseDb()
        {
            var seedTasks = new List<Task>
            {
                SeedCurrencies(),
                SeedExpenseTypes()
            };

            await Task.WhenAll(seedTasks);
        }

        public async Task SeedCurrencies()
        {
            using (var db = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (db.Currencies.Any())
                {
                    return;
                }

                db.Currencies.AddRange(
                    new Currency { Symbol = "£", Name = "GBP" },
                    new Currency { Symbol = "€", Name = "EUR" },
                    new Currency { Symbol = "$", Name = "USD" },
                    new Currency { Symbol = "¥", Name = "JPY" },
                    new Currency { Symbol = "₩", Name = "KRW" },
                    new Currency { Symbol = "﷼", Name = "SAR" },
                    new Currency { Symbol = "₽", Name = "RUB" },
                    new Currency { Symbol = "R", Name = "ZAR" }
                );

                await db.SaveChangesAsync();
            }
        }

        public async Task SeedExpenseTypes()
        {
            using (var db = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (db.ExpenseTypes.Any())
                {
                    return;
                }

                db.ExpenseTypes.AddRange(
                    new ExpenseType { Name = "Bills & Services" },
                    new ExpenseType { Name = "Entertainment" },
                    new ExpenseType { Name = "Transport" },
                    new ExpenseType { Name = "Groceries" },
                    new ExpenseType { Name = "Home" },
                    new ExpenseType { Name = "Eating Out" },
                    new ExpenseType { Name = "Family" },
                    new ExpenseType { Name = "General" },
                    new ExpenseType { Name = "Lifestyle" },
                    new ExpenseType { Name = "Shopping" },
                    new ExpenseType { Name = "Holidays" }
                );

                await db.SaveChangesAsync();
            }
        }
    }
}
