using ServiceStack.Data;
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
                    ?? "App_Data/chinook.sqlite",
                    SqliteDialect.Provider));
            });
        }
    }
}