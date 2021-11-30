using Chinook.ServiceInterface;
using Funq;
using Microsoft.AspNetCore.Hosting;
using ServiceStack;

[assembly: HostingStartup(typeof(Chinook.AppHost))]

namespace Chinook
{
    public class AppHost : AppHostBase, IHostingStartup
    {
        public AppHost() : base("Chinook", typeof(MyServices).Assembly) { }

        // Configure your AppHost with the necessary configuration and dependencies your App needs
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), false),
                UseSameSiteCookies = true
            });
            
                        
            Plugins.Add(new CorsFeature(
                new[]
                {
                    "http://localhost:3000",
                    "https://docs-vitepress.servicestack.net"
                },
                allowCredentials: true,
                allowedHeaders: "Content-Type, Allow, Authorization"
            ));
        }

        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => {
                    // Configure ASP.NET Core IOC Dependencies
                })
                .Configure(app => {
                    // Configure ASP.NET Core App
                    if (!HasInit)
                        app.UseServiceStack(new AppHost());
                });
        }
    }
}