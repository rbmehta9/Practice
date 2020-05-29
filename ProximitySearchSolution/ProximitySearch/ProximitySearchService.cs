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
        private readonly IFileParser _fileParser;
        public ProximitySearchService(IArgumentParser argumentParser, IFileParser fileParser)
        {
            _argumentParser = argumentParser;
            _fileParser = fileParser;
        }
        public int FindNumberofMatches(string[] args)
        {
            var proximitySearchRequest = _argumentParser.ParseArguments(args);
            var words = _fileParser.GetAllWords(proximitySearchRequest.FileName);
            return 5;
        }
    }
}
