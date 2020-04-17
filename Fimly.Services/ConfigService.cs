using Fimly.Data;
using Fimly.Data.Models;
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

        public async Task CreateUserConfig(string userId)
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
