using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VitalographTest.Logic.Concretes;
using VitalographTest.Logic.Interfaces;

namespace VitalographTest
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(confs => confs.AddConsole());
            services.AddTransient<ICharacterShiftService, CharacterShiftService>();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(ConfigureServices);
    }
}
