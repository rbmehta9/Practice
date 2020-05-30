using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProximitySearch;

namespace ProximitySearchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IProximitySearchService, ProximitySearchService>()
                .AddScoped<IArgumentParser, ArgumentParser>()
                .AddScoped<IProximitySearchCalculator, ProximitySearchCalculator>()
                .BuildServiceProvider();

            var proximitySearchService = serviceProvider.GetService<IProximitySearchService>();
            var response = proximitySearchService.FindNumberofMatches(args);

            if (response.NumberofMatches.HasValue)
                Console.WriteLine($"Number of Matches {response.NumberofMatches}");
            else
                Console.WriteLine($"ProximitySearchService errored out with the message {response.ErrorMessage}");

            
            
        }
    }
}
