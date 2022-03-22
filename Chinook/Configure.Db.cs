using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

[assembly: HostingStartup(typeof(Chinook.ConfigureDb))]

namespace Chinook
{
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
                services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
                    context.Configuration.GetConnectionString("DefaultConnection")
                    ?? "chinook.sqlite",
                    SqliteDialect.Provider));
            });
        }
    }
}