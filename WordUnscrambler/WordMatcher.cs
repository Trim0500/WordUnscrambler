using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {

        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            //Returns list of MatchedWord structs, list will dynamically changed based on matched words found
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
            {
                char[] sortScram = scrambledWord.ToCharArray();
                Array.Sort(sortScram);
                string tempSortScramWord = null;
                StringBuilder SBScram = new StringBuilder(tempSortScramWord);
                foreach (char nextLetterS in sortScram)
                {
                    SBScram.Append(nextLetterS);
                }
                foreach (string word in wordList)
                {
                    char[] sort = word.ToCharArray();
                    Array.Sort(sort);
                    string tempSortWord = null;
                    StringBuilder SBWord = new StringBuilder(tempSortWord);
                    foreach (char nextLetter in sort)
                    {
                        SBWord.Append(nextLetter);
                    }
                    if (SBScram.ToString().Equals(SBWord.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word});
                    }
                }
            }
            return matchedWords;
        }
        MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };
            return matchedWord;
        }
    }
}
