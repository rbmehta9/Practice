using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    public interface IFileParser
    {
        IEnumerable<string> GetAllWords(string fileName);
    }

    public class FileParser : IFileParser
    {
        public IEnumerable<string> GetAllWords(string fileName)
        {
            var text = File.ReadAllLines(fileName).ToList();
            return text.GetWords();
        }
    }
}
