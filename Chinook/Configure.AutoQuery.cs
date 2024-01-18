using ServiceStack;

[assembly: HostingStartup(typeof(Chinook.ConfigureAutoQuery))]

namespace Chinook
{
    public class ConfigureAutoQuery : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddPlugin(new AutoQueryFeature {
                    MaxLimit = 1000,
                    IncludeTotal = true,
                    // Enable AutoGen to generate APIs and Models for RDBMS:
                    // GenerateCrudServices = new GenerateCrudServices {
                    //     AutoRegister = true,
                    //     AddDataContractAttributes = false,
                    // }
                    // Command to export all AutoGen Types into code-first dtos.cs
                    // $ x csharp https://localhost:5001 -path /crud/all/csharp
                });
            });
        }
    }
}