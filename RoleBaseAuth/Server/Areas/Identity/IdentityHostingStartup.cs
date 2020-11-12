using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(RoleBaseAuth.Server.Areas.Identity.IdentityHostingStartup))]
namespace RoleBaseAuth.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder.ConfigureServices((context, services) =>
        {
        });
    }
}