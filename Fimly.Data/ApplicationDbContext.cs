using Fimly.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fimly.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, Symbol = "£", Name = "GBP" },
                new Currency { Id = 2, Symbol = "€", Name = "EUR" },
                new Currency { Id = 3, Symbol = "$", Name = "USD" },
                new Currency { Id = 4, Symbol = "¥", Name = "JPY" },
                new Currency { Id = 5, Symbol = "₩", Name = "KRW" },
                new Currency { Id = 6, Symbol = "﷼", Name = "SAR" },
                new Currency { Id = 7, Symbol = "₽", Name = "RUB" },
                new Currency { Id = 8, Symbol = "R", Name = "ZAR" }
            );

            modelBuilder.Entity<ExpenseType>().HasData(
                new ExpenseType { Id = Guid.NewGuid(), Name = "Bills & Services", Icon = "fas fa-money-bill-wave" },
                new ExpenseType { Id = Guid.NewGuid(), Name = "Entertainment", Icon = "fas fa-glass-cheers" },
                new ExpenseType { Id = Guid.NewGuid(), Name = "Transport", Icon = "fas fa-bus-alt" },
                new ExpenseType { Id = Guid.NewGuid(), Name = "Groceries", Icon = "fas fa-utensils" },
                new ExpenseType { Id = Guid.NewGuid(), Name = "Home", Icon = "fas fa-home" },
                new ExpenseType { Id = Guid.NewGuid(), Name = "Eating Out", Icon = "fas fa-pizza-slice" },
                new ExpenseType { Id = Guid.NewGuid(), Name = "Family", Icon = "fas fa-users" },
                new ExpenseType { Id = Guid.NewGuid(), Name = "General", Icon = "fas fa-money-check" },
                new ExpenseType { Id = Guid.NewGuid(), Name = "Lifestyle", Icon = "fas fa-heartbeat" },
                new ExpenseType { Id = Guid.NewGuid(), Name = "Shopping", Icon = "fas fa-shopping-basket" },
                new ExpenseType { Id = Guid.NewGuid(), Name = "Holidays", Icon = "fas fa-plane" }
            );

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Config> Configs { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<Person> People { get; set; }
    }
}
