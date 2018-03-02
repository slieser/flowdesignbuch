using System;
using System.Collections.Generic;
using System.Linq;

namespace wordcount
{
    public class WordCounter
    {
        public int CountWords(string text) {
            var words = SplitTextIntoWords(text);
            var numberOfWords = CountNumberOfWords(words);
            return numberOfWords;
        }

        private IEnumerable<string> SplitTextIntoWords(string text) {
            return text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        }

        private int CountNumberOfWords(IEnumerable<string> words) {
            return words.Count();
        }
    }
}