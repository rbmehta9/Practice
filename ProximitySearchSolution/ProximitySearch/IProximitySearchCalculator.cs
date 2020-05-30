using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    /// <summary>
    /// Calculate matches for proximity search
    /// </summary>
    public interface IProximitySearchCalculator
    {
        /// <summary>
        /// Calculate matches for proximity search
        /// </summary>
        /// <param name="request"></param>
        /// <returns>integer for number of macthes</returns>
        int FindNumberofMatches(ProximityCalculatorRequest request);
    }
}
