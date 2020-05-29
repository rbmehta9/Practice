using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    public interface IProximitySearchService
    {
        int FindNumberofMatches(string[] args);
    }

    public class ProximitySearchService : IProximitySearchService
    {
        private readonly IArgumentParser _argumentParser;
        public ProximitySearchService(IArgumentParser argumentParser)
        {
            _argumentParser = argumentParser;
        }
        public int FindNumberofMatches(string[] args)
        {
            var proximitySearchRequest = _argumentParser.ParseArguments(args);
            return 5;
        }
    }
}
