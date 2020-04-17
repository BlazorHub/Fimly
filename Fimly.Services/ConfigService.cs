using Fimly.Data;
using Fimly.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Fimly.Services
{
    public class ConfigService
    {
        private readonly ApplicationDbContext _db;

        public ConfigService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Config> GetUserConfigAsync(string userId)
        {
            return await _db.Configs
                .Include(c => c.Currency)
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task CreateUserConfigAsync(string userId)
        {
            Config userConfig = new Config
            {
                UserId = userId,
                CurrencyId = 1
            };

            _db.Configs.Add(userConfig);
            await _db.SaveChangesAsync();
        }
    }
}
