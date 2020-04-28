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
    public class PersonService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<PersonService> _logger;
        private readonly ExpenseService _expenseService;

        public PersonService(IServiceProvider serviceProvider,
            ILogger<PersonService> logger,
            ExpenseService expenseService)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _expenseService = expenseService;
        }

        public async Task<List<Person>> GetPeopleAsync(string userId)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                return await context.People
                    .Where(u => u.UserId == userId && !u.IsSharedPerson)
                    .Include(e => e.Expenses)
                        .ThenInclude(t => t.ExpenseType)
                    .ToListAsync();
            }
        }

        public async Task<List<Person>> GetPeopleAndSharedAsync(string userId)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                return await context.People
                    .Where(u => u.UserId == userId)
                    .Include(e => e.Expenses)
                        .ThenInclude(t => t.ExpenseType)
                    .ToListAsync();
            }
        }

        public int GetPeopleCount(string userId)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                return context.People.Where(u => u.UserId == userId).Count();
            }
        }

        public async Task CreatePersonAsync(Person person)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.People.Add(person);
                await context.SaveChangesAsync();

                _logger.LogInformation("A new person has been created.");
            }
        }

        public async Task CreateSharedExpensesPerson(string userId)
        {
            Person sharedExpensesPerson = new Person
            {
                Name = "Shared",
                IsSharedPerson = true,
                UserId = userId
            };

            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.People.Add(sharedExpensesPerson);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdatePersonAsync(Person person)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.Entry(person).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();

                    _logger.LogInformation("A person has been updated.");
                }
                catch (DbUpdateConcurrencyException e)
                {
                    _logger.LogError($"An error has occurred whilst trying to update a person: {e}");
                }
            }
        }

        public async Task DeletePersonAsync(Guid id)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                var person = await context.People.FindAsync(id);

                if (person is null)
                {
                    _logger.LogError("Error deleting person: Person not found.");
                    return;
                }

                await _expenseService.DeleteAllPersonsExpenses(person.Id);

                context.People.Remove(person);
                await context.SaveChangesAsync();

                _logger.LogInformation("A person has been deleted.");
            }
        }
    }
}
