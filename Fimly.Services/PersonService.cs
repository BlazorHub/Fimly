using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class PersonService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<PersonService> _logger;

        public PersonService(ApplicationDbContext db,
            ILogger<PersonService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<Person>> GetPeopleAsync(string userId)
        {
            return await _db.People
                .Where(u => u.UserId == userId)
                .Include(e => e.Expenses)
                .ThenInclude(t => t.ExpenseType)
                .ToListAsync();
        }

        public async Task CreatePersonAsync(Person person)
        {
            _db.People.Add(person);
            await _db.SaveChangesAsync();

            _logger.LogInformation("A new person has been created.");
        }

        public async Task UpdatePersonAsync(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();

                _logger.LogInformation("A person has been updated.");
            }
            catch (DbUpdateConcurrencyException e)
            {
                _logger.LogError($"An error has occurred whilst trying to update a person: {e}");
            }
        }
    }
}
