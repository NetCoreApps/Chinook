using ServiceStack;

namespace Chinook
{
    public class ConfigureAutoQuery : IConfigureAppHost
    {
        public void Configure(IAppHost appHost)
        {
            appHost.Plugins.Add(new AutoQueryFeature {
                MaxLimit = 1000,
                IncludeTotal = true,
                GenerateCrudServices = new GenerateCrudServices {
                    AutoRegister = true
                }
            });
        }
    }
}
