using Funq;
using Chinook.ServiceInterface;
using ServiceStack;

[assembly: HostingStartup(typeof(Chinook.AppHost))]

namespace Chinook
{
    public class AppHost : AppHostBase, IHostingStartup
    {
        public AppHost() : base("Chinook", typeof(MyServices).Assembly) { }

        public void Configure(IWebHostBuilder builder) =>
            builder.ConfigureServices(services => {
                // Configure ASP.NET Core IOC Dependencies
            });

        public override void Configure(Container container)
        {
            SetConfig(new HostConfig {
                // DebugMode = false,
                UseSameSiteCookies = true
            });
            
            ConfigurePlugin<UiFeature>(feature => 
                feature.Info.BrandIcon = new ImageInfo { Uri = "/logo.svg", Cls = "w-8 h-8 mr-2" });

            Plugins.Add(new CorsFeature(new[] {
                    "http://localhost:3000",
                    "https://docs.servicestack.net"
                },
                allowCredentials: true,
                allowedHeaders: "Content-Type, Allow, Authorization"
            ));
        }
    }
}