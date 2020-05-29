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

    /// <summary>
    /// Parse arguments
    /// </summary>
    public class ArgumentParser : IArgumentParser
    {
        private const int NUMBER_OF_ARGUMENTS = 4;
        private const string FILE_EXTENSION = "txt";

        /// <summary>
        /// Parse Arguments
        /// </summary>
        /// <param name="args"></param>
        /// <returns>ProximitySearchRequest with keyword1, keyword2, range, filename</returns>
        public ProximitySearchRequest ParseArguments(string[] args)
        {
            if (args.Length < NUMBER_OF_ARGUMENTS)
                throw new ArgumentException($"Please provide {NUMBER_OF_ARGUMENTS} arguments <keyword1> <keyword2> <range> <inputfile>");

             int range;
            if (!int.TryParse(args[2], out range))
                throw new ArgumentException($"Range argument must me an integer");

            var periodIndex = args[3].IndexOf(".");
            if(periodIndex == -1)
                throw new ArgumentException($"File must have an extension {FILE_EXTENSION}");

            if (!isValidFileExtension())
            {
                throw new ArgumentException($"File extension must be {FILE_EXTENSION}");
            }

            return new ProximitySearchRequest()
            {
                FileName = args[3],
                KeyWords = new List<string> { args[0], args[1] },
                Range = range
            };

            bool isValidFileExtension()
            {
                var extension = args[3].Substring(periodIndex + 1);
                var isLengthValid = extension.Length == FILE_EXTENSION.Length;
                var isExtensionValid = extension.Equals(FILE_EXTENSION, StringComparison.InvariantCultureIgnoreCase);
                return isLengthValid && isExtensionValid;
            }
        }


    }

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
