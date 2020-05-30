using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    /// <summary>
    /// Parse file to get all words in an ienumerable
    /// </summary>
    public interface IFileParser
    {
        IEnumerable<string> GetAllWords(string fileName);
    }
}
