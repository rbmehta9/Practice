using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    public class ProximityCalculatorResponse
    {
        public int? NumberofMatches { get; set; }
        public string ErrorMessage { get; set; }
        public string DisplayMessage
        {
            get
            {
                if (NumberofMatches.HasValue)
                    return $"Number of Matches {NumberofMatches}";

                return ErrorMessage;
            }
        }
    }
}
