using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProximitySearch.UnitTests
{
    [TestClass]
    public class ArgumentParserUnitTest
    {
        [TestMethod]
        public void When_Fewer_InputArguments_Throws_Exception()
        {
            var args = new string[3] { "kw1", "kw2", "2" };
            var exception = Assert.ThrowsException<ArgumentException>(() => new ArgumentParser().ParseArguments(args));
            const int NUMBER_OF_ARGUMENTS = 4;
            Assert.AreEqual($"Please provide {NUMBER_OF_ARGUMENTS} arguments <keyword1> <keyword2> <range> <inputfile>", exception.Message);

        }

        [TestMethod]
        public void When_InputArgument_Range_Not_An_Integer_Throws_Exception()
        {
            var args = new string[4] { "kw1", "kw2", "gfgf", "abc.txt" };
            var exception = Assert.ThrowsException<ArgumentException>(() => new ArgumentParser().ParseArguments(args));
            Assert.AreEqual("Range argument must me an integer", exception.Message);

        }

        [TestMethod]
        public void When_InputArgument_Valid_Returns_ProximitySearchRequest()
        {
            var args = new string[4] { "kw1", "kw2", "2", "abc" };
            var proximitySearchRequest = new ArgumentParser().ParseArguments(args);
            Assert.IsTrue(proximitySearchRequest.KeyWords.Contains(args[0]));
            Assert.IsTrue(proximitySearchRequest.KeyWords.Contains(args[1]));
            Assert.AreEqual(2, proximitySearchRequest.Range);
            Assert.AreEqual(args[3], proximitySearchRequest.FileName);

        }
    }
}
