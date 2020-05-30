using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProximitySearch;

namespace ProximitySearch.UnitTests
{
    [TestClass]
    public class TextCleanUpHelperTest
    {
        [TestMethod]
        public void Cleans_Up_Extra_Space_UnWanted_Chars_Returns_Clean_Words()
        {
            var unCleanedWords = new List<string>()
            {
                "Hello\tabc\txyz",
                "aasdasd\tbng\t\r\n",
                "abc\t\n",
                "\t",
                "?."
            };

            var words = unCleanedWords.GetWords();
            Assert.AreEqual(7, words.Count());
            Assert.AreEqual("Hello", words.ElementAt(0));
            Assert.AreEqual("abc", words.ElementAt(1));
            Assert.AreEqual("xyz", words.ElementAt(2));
            Assert.AreEqual("aasdasd", words.ElementAt(3));
            Assert.AreEqual("bng", words.ElementAt(4));
            Assert.AreEqual("abc", words.ElementAt(5));
            Assert.AreEqual("?.", words.ElementAt(6));
        }
    }
}
