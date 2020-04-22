﻿using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class PersonService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<PersonService> _logger;
        private readonly ExpenseService _expenseService;

        public PersonService(ApplicationDbContext db,
            ILogger<PersonService> logger,
            ExpenseService expenseService)
        {
            _db = db;
            _logger = logger;
            _expenseService = expenseService;
        }

        public async Task<List<Person>> GetPeopleAsync(string userId)
        {
            var people = await _db.People
                .Where(u => u.UserId == userId)
                .Include(e => e.Expenses)
                .ThenInclude(t => t.ExpenseType)
                .ToListAsync();

            foreach (var person in people)
            {
                var expensesToRemove = person.Expenses.Where(e => e.IsShared).ToList();

                foreach (var item in expensesToRemove)
                {
                    person.Expenses.Remove(item);
                }
            }

            return people;
        }

        public int GetPeopleCount(string userId)
        {
            return _db.People.Where(u => u.UserId == userId).Count();
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

        public async Task DeletePersonAsync(Guid id)
        {
            var person = await _db.People.FindAsync(id);

            if (person == null)
            {
                _logger.LogError("Error deleting person: Person not found.");

                return;
            }

            await _expenseService.DeleteAllPersonsExpenses(person.Id);

            _db.People.Remove(person);
            await _db.SaveChangesAsync();

            _logger.LogInformation("A person has been deleted.");
        }
    }
}
