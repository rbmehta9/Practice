using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    /// <summary>
    /// Request object for performing proximity search
    /// </summary>
    public class ProximitySearchRequest
    {
        /// <summary>
        /// FileName
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Max range to check for keywords
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// Keywords
        /// </summary>
        public List<string> KeyWords { get; set; }
    }
}
