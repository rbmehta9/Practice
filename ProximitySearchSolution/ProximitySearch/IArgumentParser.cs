using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    /// <summary>
    /// Parse arguments
    /// </summary>
    public interface IArgumentParser
    {
        /// <summary>
        /// Parse Arguments
        /// </summary>
        /// <param name="args"></param>
        /// <returns>ProximitySearchRequest with keyword1, keyword2, range, filename</returns>
        ProximitySearchRequest ParseArguments(string[] args);
    }
}
