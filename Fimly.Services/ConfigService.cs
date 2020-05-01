using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class ConfigService
    {
        private readonly ILogger<ConfigService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ConfigService(ILogger<ConfigService> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<Config> GetUserConfigAsync(string userId)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                return await context.Configs
                    .Include(c => c.Currency)
                    .Where(u => u.UserId == userId)
                    .FirstOrDefaultAsync();
            }
        }

        public async Task CreateDefaultConfigAsync(string userId)
        {
            Config userConfig = new Config
            {
                UserId = userId,
                CurrencyId = 1
            };

            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.Configs.Add(userConfig);
                await context.SaveChangesAsync();

                _logger.LogInformation("Created default config for a user account.");
            }
        }

        public async Task UpdateConfigAsync(Config config)
        {
            using (var context = _serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.Entry(config).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();

                    _logger.LogInformation("Config settings updated.");
                }
                catch (DbUpdateConcurrencyException e)
                {
                    _logger.LogError($"An error has occurred whilst trying to update app config: {e}");
                }
            }
        }
    }
}
