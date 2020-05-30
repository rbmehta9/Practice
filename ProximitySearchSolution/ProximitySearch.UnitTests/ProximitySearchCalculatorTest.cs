using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch.UnitTests
{
    [TestClass]
    public class ProximitySearchCalculatorTest
    {
        [TestMethod]
        public void If_Range_Less_Than_KeyWord_Length_Throws_Exception()
        {
            var request = new ProximityCalculatorRequest
            {
                KeyWords = new List<string>() { "abc", "test", "xyz" },
                TextWords = new List<string>() { "abc", "test", "def", "lmn" },
                Range = 2
            };

            var exception = Assert.ThrowsException<ArgumentException>(() => new ProximitySearchCalculator().FindNumberofMatches(request));
            Assert.AreEqual($"The range must be atleast {request.KeyWords.Count()}", exception.Message);
        }

        [TestMethod]
        public void If_Keywords_Repeated_Than_Throws_Exception()
        {
            var request = new ProximityCalculatorRequest
            {
                KeyWords = new List<string>() { "abc", "abc", "xyz" },
                TextWords = new List<string>() { "abc", "test", "def", "lmn" },
                Range = 4
            };

            var exception = Assert.ThrowsException<ArgumentException>(() => new ProximitySearchCalculator().FindNumberofMatches(request));
            Assert.AreEqual("Keywords cannot be repeated", exception.Message);
        }

        [TestMethod]
        public void If_Valid_Request_Returns_Correct_Response1()
        {
            var request = new ProximityCalculatorRequest
            {
                KeyWords = new List<string>() { "the", "canal" },
                TextWords = new List<string>() {
                                                "the",
                                                "man",
                                                "the",
                                                "plan",
                                                "the",
                                                "canal",
                                                "panama",
                                                "panama",
                                                "canal",
                                                "the",
                                                "plan",
                                                "the",
                                                "man",
                                                "the",
                                                "the",
                                                "man",
                                                "the",
                                                "plan",
                                                "the",
                                                "canal",
                                                "panama"
                                                },
                 Range = 6
            };

            Assert.AreEqual(11, new ProximitySearchCalculator().FindNumberofMatches(request));
        }

        [TestMethod]
        public void If_Valid_Request_Returns_Correct_Response2()
        {
            var request = new ProximityCalculatorRequest
            {
                KeyWords = new List<string>() { "the", "canal" },
                TextWords = new List<string>() {
                                                "the",
                                                "man",
                                                "the",
                                                "plan",
                                                "the",
                                                "canal",
                                                "panama",
                                                },
                Range = 6
            };

            Assert.AreEqual(3, new ProximitySearchCalculator().FindNumberofMatches(request));
        }

        [TestMethod]
        public void If_Valid_Request_Returns_Correct_Response3()
        {
            var request = new ProximityCalculatorRequest
            {
                KeyWords = new List<string>() { "the", "canal" },
                TextWords = new List<string>() {
                                                "the",
                                                "man",
                                                "the",
                                                "plan",
                                                "the",
                                                "canal",
                                                "panama",
                                                },
                Range = 3
            };

            Assert.AreEqual(1, new ProximitySearchCalculator().FindNumberofMatches(request));
        }

        [TestMethod]
        public void If_Valid_Request_Returns_Correct_Response4()
        {
            var request = new ProximityCalculatorRequest
            {
                KeyWords = new List<string>() { "the", "canal", "panama" },
                TextWords = new List<string>() {
                                                "the",
                                                "man",
                                                "the",
                                                "plan",
                                                "the",
                                                "canal",
                                                "panama",
                                                "panama",
                                                "canal",
                                                "the",
                                                "plan",
                                                "the",
                                                "man",
                                                "the",
                                                "the",
                                                "man",
                                                "the",
                                                "plan",
                                                "the",
                                                "canal",
                                                "panama"
                                                },
                Range = 6
            };

            Assert.AreEqual(14, new ProximitySearchCalculator().FindNumberofMatches(request));
        }

        [TestMethod]
        public void If_Valid_Request_Returns_Correct_Response5()
        {
            var request = new ProximityCalculatorRequest
            {
                KeyWords = new List<string>() { "abc", "tst" },
                TextWords = new List<string>() {
                                                "the",
                                                "man",
                                                "the",
                                                "plan",
                                                "the",
                                                "canal",
                                                "panama",
                                                },
                Range = 3
            };

            Assert.AreEqual(0, new ProximitySearchCalculator().FindNumberofMatches(request));
        }



    }
}
