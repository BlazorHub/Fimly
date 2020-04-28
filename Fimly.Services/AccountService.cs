using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class AccountService
    {
        private readonly ConfigService _configService;
        private readonly PersonService _personService;
        private readonly ExpenseTypeService _expenseTypeService;
        private readonly ILogger<AccountService> _logger;

        public AccountService(ConfigService configService,
            PersonService personService,
            ExpenseTypeService expenseTypeService,
            ILogger<AccountService> logger)
        {
            _configService = configService;
            _personService = personService;
            _expenseTypeService = expenseTypeService;
            _logger = logger;
        }

        public async Task InitialiseAccount(string userId)
        {
            await _configService.CreateDefaultConfigAsync(userId);
            await _personService.CreateSharedExpensesPerson(userId);
            await _expenseTypeService.SeedDefaultExpenseTypesAsync(userId);

            _logger.LogInformation("User account initialised.");
        }
    }
}
