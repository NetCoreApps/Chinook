using Microsoft.AspNetCore.Hosting;
using ServiceStack;

[assembly: HostingStartup(typeof(Chinook.ConfigureAutoQuery))]

namespace Chinook
{
    public class ConfigureAutoQuery : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureAppHost(appHost =>
            {
                appHost.Plugins.Add(new AutoQueryFeature {
                    MaxLimit = 1000,
                    IncludeTotal = true
                });
            });
        }
    }
}