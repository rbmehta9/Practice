using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    /// <summary>
    /// Service for Proximity Search
    /// </summary>
    public interface IProximitySearchService
    {
        /// <summary>
        /// Finds number of matches in a response object
        /// </summary>
        /// <param name="args"></param>
        /// <returns>ProximityCalculatorResponse with numberofmatches and errormessage if any</returns>
        ProximityCalculatorResponse FindNumberofMatches(string[] args);
    }
}
