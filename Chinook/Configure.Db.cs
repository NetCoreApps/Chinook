using ServiceStack.Data;
using ServiceStack.OrmLite;

[assembly: HostingStartup(typeof(Chinook.ConfigureDb))]

namespace Chinook;

// Example Data Model
// public class MyTable
// {
//     [AutoIncrement]
//     public int Id { get; set; }
//     public string Name { get; set; }
// }

public class ConfigureDb : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context,services) =>
        {
            var dbFactory = new OrmLiteConnectionFactory(
                context.Configuration.GetConnectionString("DefaultConnection")
                ?? "App_Data/chinook.sqlite",
                SqliteDialect.Provider);
                
            services.AddSingleton<IDbConnectionFactory>(dbFactory);
                
            services.AddPlugin(new AutoQueryFeature {
                MaxLimit = 1000,
                IncludeTotal = true,
                // Enable AutoGen to generate APIs and Models for RDBMS:
                // GenerateCrudServices = new GenerateCrudServices {
                //     DbFactory = dbFactory, 
                //     AutoRegister = true,
                //     AddDataContractAttributes = false,
                // }
                // Command to export all AutoGen Types into code-first dtos.cs
                // $ x csharp https://localhost:5001 -path /crud/all/csharp
            });
        });
    }
}