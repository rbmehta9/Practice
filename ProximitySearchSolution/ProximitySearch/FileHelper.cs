using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    public static class TextCleanUpHelper
    {
        public static IEnumerable<string> GetWords(this List<string> text)
        {
            var words = new List<string>();
            foreach (var line in text)
            {
                var lineCleaned = line.IgnoreUnWantedCharecters();
                var lineWords = lineCleaned.Split(' ').ToList();
                lineWords.RemoveExtraSpacing();
                words.AddRange(lineWords);
            }

            return words;
        }

        public static string IgnoreUnWantedCharecters(this string s)
        {
            const char NEW_LINE = '\n';
            const char CARRIAGE_RETURN = '\r';
            const char TAB = '\t';
            return String.Join("", s.Where(c => c != NEW_LINE && c != CARRIAGE_RETURN && c != TAB));
        }

        public static void RemoveExtraSpacing(this List<string> s)
        {
            s.RemoveAll(w => string.IsNullOrEmpty(w));
        }

    }
}
