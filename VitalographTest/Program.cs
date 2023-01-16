using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using VitalographTest.Logic.Interfaces;

namespace VitalographTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Startup.CreateHostBuilder(args).Build();
            var logger = host.Services.GetService<ILoggerFactory>().CreateLogger<Program>();
            var characterShiftService = host.Services.GetService<ICharacterShiftService>();
            host.Start();

            int shift = 5;
            var input = characterShiftService.AskForUserInput();

            var output = characterShiftService.ShiftCharacters(input, shift, out bool succeeded);

            while (!succeeded)
            {
                input = characterShiftService.AskForUserInput();
                output = characterShiftService.ShiftCharacters(input, shift, out succeeded);
            }

            Console.WriteLine("Output: " + output);

            host.Dispose();
        }
    }
}
