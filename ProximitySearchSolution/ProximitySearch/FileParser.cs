using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    public class FileParser : IFileParser
    {
        /// <summary>
        /// Parse file to get all words in an ienumerable
        /// </summary>
        public IEnumerable<string> GetAllWords(string fileName)
        {
            var text = File.ReadAllLines(fileName).ToList();
            return text.GetWords();
        }
    }
}
