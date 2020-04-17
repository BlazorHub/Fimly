using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class PersonService
    {
        private readonly ApplicationDbContext _db;

        public PersonService(ApplicationDbContext db)
        {
            _db = db;
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
        }

        public async Task UpdatePersonAsync(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
