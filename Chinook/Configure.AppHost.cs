using Funq;
using Chinook.ServiceInterface;
using ServiceStack;

[assembly: HostingStartup(typeof(Chinook.AppHost))]

namespace Chinook;

public class AppHost() : AppHostBase("Chinook", typeof(MyServices).Assembly), IHostingStartup
{
    public void Configure(IWebHostBuilder builder) =>
        builder.ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
            services.AddPlugin(new CorsFeature(new[] {
                    "http://localhost:3000",
                    "https://docs.servicestack.net"
                },
                allowCredentials: true,
                allowedHeaders: "Content-Type, Allow, Authorization"
            ));
        });

    public override void Configure(Container container)
    {
        SetConfig(new HostConfig {
            // DebugMode = false,
            UseSameSiteCookies = true
        });
            
        ConfigurePlugin<UiFeature>(feature => 
            feature.Info.BrandIcon = new ImageInfo { Uri = "/logo.svg", Cls = "w-8 h-8 mr-2" });
    }
}