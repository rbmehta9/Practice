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
            var text = request.TextWords;
            var keyWords = request.KeyWords;
            var range = request.Range;

            if(range < keyWords.Count)
                throw new ArgumentException($"The range must be atleast {keyWords.Count()}");

            //O(number of words)
            var keyWordStackPositions = GetKeyWordPositions();
            if (keyWordStackPositions.Count() < keyWords.Count())
                return 0;
            var stackWithLowestPosition = default(Stack<int>);
            var numofMatches = 0;
            //O(smallerlistsize * range)
            do
            {
                //O(number of keywords)
                stackWithLowestPosition = FindStackWithLowestPosition(keyWordStackPositions);
                var prod = 1;
                int minIndex = stackWithLowestPosition.Peek();
                //O(number of keywords)
                var stacksWithHigherIndex = keyWordStackPositions.Where(k => k != stackWithLowestPosition).ToList();
                //O((number of keywords - 1)*range)
                stacksWithHigherIndex.ForEach(s =>
                {
                    //O(range)
                    prod *= s.Count(pos => pos <= minIndex + range - 1);
                });
                numofMatches += prod;
                stackWithLowestPosition.Pop();//O(1)

            }
            while (stackWithLowestPosition.Any());

            return numofMatches;

            //O(number of keywords)
            Stack<int> FindStackWithLowestPosition(List<Stack<int>> keyWordPositions)
            {
                var minIndex = text.Count;
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

            List<Stack<int>> GetKeyWordPositions()
            {
                var keyWordsCaseInsensitive = keyWords.Select(k => k.ToLower().Trim());
                var dictionaryByKeyWord = new Dictionary<string, Stack<int>>();
                for (var i = text.Count - 1; i >= 0; i--)
                {
                    var word = text[i].ToLower().Trim();
                    if (!keyWordsCaseInsensitive.Contains(word))
                        continue;
                    if (!dictionaryByKeyWord.ContainsKey(word))
                        dictionaryByKeyWord.Add(word, new Stack<int>());

                    dictionaryByKeyWord[word].Push(i);
                }

                return dictionaryByKeyWord.Values.ToList();
            }
        }
    }
}
