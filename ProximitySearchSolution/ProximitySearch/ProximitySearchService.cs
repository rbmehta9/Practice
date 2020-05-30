using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    /// <summary>
    /// Service for proximity search
    /// </summary>
    public class ProximitySearchService : IProximitySearchService
    {
        private readonly IArgumentParser _argumentParser;
        private readonly IFileParser _fileParser;
        private readonly IProximitySearchCalculator _proximitySearchCalculator;
        public ProximitySearchService(IArgumentParser argumentParser, 
                                      IFileParser fileParser, 
                                      IProximitySearchCalculator proximitySearchCalculator)
        {
            _argumentParser = argumentParser;
            _fileParser = fileParser;
            _proximitySearchCalculator = proximitySearchCalculator;
        }

        /// <summary>
        /// Finds number of matches in a response object
        /// </summary>
        /// <param name="args"></param>
        /// <returns>ProximityCalculatorResponse with numberofmatches and errormessage if any</returns>
        public ProximityCalculatorResponse FindNumberofMatches(string[] args)
        {
            var response = new ProximityCalculatorResponse();
            try
            {
                var proximitySearchRequest = _argumentParser.ParseArguments(args);
                var numberofMatches = _proximitySearchCalculator.FindNumberofMatches(new ProximityCalculatorRequest
                {
                    KeyWords = proximitySearchRequest.KeyWords,
                    Range = proximitySearchRequest.Range,
                    TextWords = _fileParser.GetAllWords(proximitySearchRequest.FileName).ToList()
                });

                response.NumberofMatches = numberofMatches;
            }
            catch(ArgumentException argsEx)
            {
                response.ErrorMessage = argsEx.Message;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
            
        }
    }
}
