using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Fimly.Areas.Identity.IdentityHostingStartup))]
namespace Fimly.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}