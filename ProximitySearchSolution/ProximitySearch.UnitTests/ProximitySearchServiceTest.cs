using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ProximitySearch.UnitTests
{
    [TestClass]
    public class ProximitySearchServiceTest
    {
        private Mock<IArgumentParser> _argumentParserMock;
        private Mock<IFileParser> _fileParserMock;
        private Mock<IProximitySearchCalculator> _proximitySearchCalculatorMock;
        [TestInitialize]
        public void Initialize()
        {
            _argumentParserMock = new Mock<IArgumentParser>();
            _fileParserMock = new Mock<IFileParser>();
            _proximitySearchCalculatorMock = new Mock<IProximitySearchCalculator>();
        }

        [TestMethod]
        public void If_Failure_ErrorMessage_Returned()
        {
            var proximitySearchRequest = new ProximitySearchRequest
            {
                FileName = "input.txt"
            };
            _argumentParserMock.Setup(a => a.ParseArguments(It.IsAny<string[]>())).Returns(proximitySearchRequest);

            var service = new ProximitySearchService(_argumentParserMock.Object, _fileParserMock.Object, new ProximitySearchCalculator());
            var response = service.FindNumberofMatches(new string[4] { "app", "the", "canal", "input.txt" });
            Assert.IsFalse(response.NumberofMatches.HasValue);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
        }

        [TestMethod]
        public void If_Arguments_Correct_Returns_Response()
        {
            var proximitySearchRequest = new ProximitySearchRequest
            {
                FileName = "input.txt",
                KeyWords = new List<string>() {
                                                "the",
                                                "canal"
                                                },
                Range = 3
            };
            _argumentParserMock.Setup(a => a.ParseArguments(It.IsAny<string[]>())).Returns(proximitySearchRequest);

            var textWords = new List<string>() {
                                                "the",
                                                "man",
                                                "the",
                                                "plan",
                                                "the",
                                                "canal",
                                                "panama",
                                                };

            _fileParserMock.Setup(f => f.GetAllWords(proximitySearchRequest.FileName)).Returns(textWords);

            var service = new ProximitySearchService(_argumentParserMock.Object, _fileParserMock.Object, new ProximitySearchCalculator());
            var response = service.FindNumberofMatches(new string[4] { "app", "the", "canal", "input.txt" });
            Assert.IsTrue(response.NumberofMatches >= 0);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
        }
    }
}
