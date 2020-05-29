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
                "Hello",
                "aasdasd\r\n",
                "",
                "",
                "?."
            };

            var words = unCleanedWords.GetWords();
            Assert.AreEqual(3, words.Count());
            Assert.AreEqual("aasdasd", words.ElementAt(1));
        }
    }
}
