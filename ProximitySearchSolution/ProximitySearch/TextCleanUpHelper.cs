using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    /// <summary>
    /// Helper class for text cleanup
    /// </summary>
    public static class TextCleanUpHelper
    {
        const char NEW_LINE = '\n';
        const char CARRIAGE_RETURN = '\r';
        const char TAB = '\t';
        const char SPACE = ' ';
        public static IEnumerable<string> GetWords(this List<string> text)
        {
            var words = new List<string>();
            foreach (var line in text)
            {
                var lineCleaned = line.ReplaceTabsWithSpacing();
                lineCleaned = lineCleaned.IgnoreUnWantedCharecters();
                var lineWords = lineCleaned.Split(SPACE).ToList();
                lineWords.RemoveExtraSpacing();
                words.AddRange(lineWords);
            }

            return words;
        }

        public static string IgnoreUnWantedCharecters(this string s)
        {
            return String.Join("", s.Where(c => c != NEW_LINE && c != CARRIAGE_RETURN));
        }

        public static string ReplaceTabsWithSpacing(this string s)
        {
            return s.Replace(TAB, SPACE);
        }

        public static void RemoveExtraSpacing(this List<string> s)
        {
            s.RemoveAll(w => string.IsNullOrEmpty(w));
        }

    }
}
