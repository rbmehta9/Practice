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
                .BuildServiceProvider();

            var proximitySearchService = serviceProvider.GetService<IProximitySearchService>();
            Console.WriteLine($"Number of Matches {proximitySearchService.FindNumberofMatches(args)}");

            
            
        }
    }
}
