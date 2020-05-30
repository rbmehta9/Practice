using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    public class ProximityCalculatorRequest
    {
        /// <summary>
        /// Max range to check for keywords
        /// </summary>
        public int Range { get; set; }

        /// <summary>
        /// Keywords
        /// </summary>
        public List<string> KeyWords { get; set; }

        /// <summary>
        /// All words from file
        /// </summary>
        public List<string> TextWords { get; set; }
    }


    public interface IProximitySearchCalculator
    {
        int FindNumberofMatches(ProximityCalculatorRequest request);
    }

    public class ProximitySearchCalculator : IProximitySearchCalculator
    {
        public int FindNumberofMatches(ProximityCalculatorRequest request)
        {
            if(request.Range < request.KeyWords.Count)
                throw new ArgumentException($"The range must be atleast {request.KeyWords.Count()}");

            var keyWordStackPositions = GetKeyWordPositions(request.TextWords, request.KeyWords);
            if (keyWordStackPositions.Count() < request.KeyWords.Count())
                return 0;
            var stackWithLowestPosition = default(Stack<int>);
            var numofMatches = 0;
            do
            {
                stackWithLowestPosition = FindStackWithLowestPosition(request.TextWords, keyWordStackPositions);
                var prod = 1;
                int minIndex = stackWithLowestPosition.Peek();
                var stacksWithHigherIndex = keyWordStackPositions.Where(k => k != stackWithLowestPosition);
                foreach(var stack in stacksWithHigherIndex)
                    prod *= stack.Count(pos => pos <= minIndex + request.Range - 1);

                numofMatches += prod;
                stackWithLowestPosition.Pop();

            }
            while (stackWithLowestPosition.Any());

            return numofMatches;

        }

        private List<Stack<int>> GetKeyWordPositions(List<string> textWords,  List<string> keyWords)
        {
            var keyWordsCaseInsensitive = keyWords.Select(k => k.ToLower().Trim());
            var dictionaryByKeyWord = new Dictionary<string, Stack<int>>();
            for (var i = textWords.Count - 1; i >= 0; i--)
            {
                var word = textWords[i].ToLower().Trim();
                if (!keyWordsCaseInsensitive.Contains(word))
                    continue;
                if (!dictionaryByKeyWord.ContainsKey(word))
                    dictionaryByKeyWord.Add(word, new Stack<int>());

                dictionaryByKeyWord[word].Push(i);
            }

            return dictionaryByKeyWord.Values.ToList();
        }

        private Stack<int> FindStackWithLowestPosition(List<string> textWords, List<Stack<int>> keyWordPositions)
        {
            var minIndex = textWords.Count;
            var stackWithLowermostPosition = default(Stack<int>);
            foreach (var stack in keyWordPositions)
            {
                var peek = stack.Peek();
                if (peek < minIndex)
                {
                    minIndex = peek;
                    stackWithLowermostPosition = stack;
                }

            }
            return stackWithLowermostPosition;
        }
    }
}
