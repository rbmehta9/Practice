using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    public class ProximityCalculatorRequest
    {
        /// <summary>
        /// Max range to check for keywords
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// Keywords
        /// </summary>
        public List<string> KeyWords { get; set; }

        /// <summary>
        /// All words from file
        /// </summary>
        public List<string> TextWords { get; set; }
    }
}
