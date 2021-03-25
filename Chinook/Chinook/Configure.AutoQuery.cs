using ServiceStack;

namespace Chinook
{
    public class ConfigureAutoQuery : IConfigureAppHost
    {
        public void Configure(IAppHost appHost)
        {
            appHost.Plugins.Add(new AutoQueryFeature {
                MaxLimit = 1000,
                GenerateCrudServices = new GenerateCrudServices {
                    AutoRegister = true
                }
            });
        }
    }
}
