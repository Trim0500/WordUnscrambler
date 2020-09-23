using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher //This class will create a list of matched words so the driver class may display them
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList) //Create the match method w/2 string arrays as arguments (the scrambled words & the word list)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>(); //Returns list of MatchedWord structs, list will dynamically changed based on matched words found

            foreach (string scrambledWord in scrambledWords) //Use a foreach loop to cycle through all the scrambled words
            {
                char[] sortScram = scrambledWord.ToCharArray(); //Put the words in a character array to sort
                Array.Sort(sortScram); //Sort the array

                StringBuilder SBScram = new StringBuilder(); //Create a string builder to put the sorted letters back in as a string

                foreach (char nextLetterS in sortScram) //Use a foreach loop to cycle through each letter
                {
                    SBScram.Append(nextLetterS);
                }

                foreach (string word in wordList) //Nested foreach loop to test each comparable word w/the scrambled words
                {
                    char[] sort = word.ToCharArray();
                    Array.Sort(sort);

                    StringBuilder SBWord = new StringBuilder();

                    foreach (char nextLetter in sort)
                    {
                        SBWord.Append(nextLetter);
                    }

                    if (SBScram.ToString().Equals(SBWord.ToString(), StringComparison.OrdinalIgnoreCase)) //Test to see if a match was found
                    {
                        Console.WriteLine("A match was found for {0} and {1}!", scrambledWord, word);
                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word}); //Add the couple of words as new instances of each variable
                    }
                    else //If the test fails to find a match
                    {
                        Console.WriteLine("No Match was found for {0} and {1}", scrambledWord, word);
                    }
                }
            }
            return matchedWords; //Return the array of matches so the driver may use them to display the results
        }
    }
}
