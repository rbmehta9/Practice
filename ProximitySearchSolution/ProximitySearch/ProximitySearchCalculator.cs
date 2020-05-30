using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProximitySearch
{
    /// <summary>
    /// Calculate matches for proximity search
    /// </summary>
    public class ProximitySearchCalculator : IProximitySearchCalculator
    {
        /// <summary>
        /// Calculate matches for proximity search
        /// </summary>
        /// <param name="request"></param>
        /// <returns>integer for number of macthes</returns>
        public int FindNumberofMatches(ProximityCalculatorRequest request)
        {
            if (request.Range < request.KeyWords.Count)
                throw new ArgumentException($"The range must be atleast {request.KeyWords.Count()}");

            var keyWordStackPositions = GetKeyWordPositions(request.TextWords, request.KeyWords);
            if (keyWordStackPositions.Count() < request.KeyWords.Count())
                return 0;
            var stackWithMinimumPosition = default(Stack<int>);
            var numofMatches = 0;
            do
            {
                stackWithMinimumPosition = FindStackWithMinimumPosition(request.TextWords, keyWordStackPositions);
                var prod = 1;
                int minIndex = stackWithMinimumPosition.Peek();
                var stacksNotHavingMinimumPosition = keyWordStackPositions.Where(k => k != stackWithMinimumPosition);
                foreach (var stack in stacksNotHavingMinimumPosition)
                    prod *= stack.Count(pos => pos <= minIndex + request.Range - 1);

                numofMatches += prod;
                stackWithMinimumPosition.Pop();

            }
            while (stackWithMinimumPosition.Any());

            return numofMatches;

        }

        private List<Stack<int>> GetKeyWordPositions(List<string> textWords, List<string> keyWords)
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

        private Stack<int> FindStackWithMinimumPosition(List<string> textWords, List<Stack<int>> keyWordPositions)
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
