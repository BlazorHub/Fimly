using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class ConfigService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ConfigService> _logger;

        public ConfigService(ApplicationDbContext db,
            ILogger<ConfigService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<Config> GetUserConfigAsync(string userId)
        {
            return await _db.Configs
                .Include(c => c.Currency)
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task CreateDefaultConfigAsync(string userId)
        {
            Config userConfig = new Config
            {
                UserId = userId,
                CurrencyId = 1
            };

            _db.Configs.Add(userConfig);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Created default config for a user account.");
        }

        public async Task UpdateConfigAsync(Config config)
        {
            _db.Entry(config).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();

                _logger.LogInformation("Config settings updated.");
            }
            catch (DbUpdateConcurrencyException e)
            {
                _logger.LogError($"An error has occurred whilst trying to update app config: {e}");
            }
        }
    }
}
