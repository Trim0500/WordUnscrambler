using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        //Make file reader and word matcher
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the scrambled words manually or as a file ---> f - file, m - manual:");

            string option = Console.ReadLine() ?? throw new Exception("String is empty");

            while ((option != "f" && option != "F") && (option != "m" && option != "M"))
            {
                Console.WriteLine("Sorry, your choice is incomprehensible, try again.");
                Console.WriteLine("Enter the scrambled words manually or as a file ---> f - file, m - manual:");
                option = Console.ReadLine() ?? throw new Exception("String is empty");
            }

            try
            {
                switch (option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Enter the full path w/the file name:");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M":
                        Console.WriteLine("Enter the word(s), seperated by a comma:");
                        ExecuteSccrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine("The entered option was not valid, try again.");
                        break;
                }
            }

            catch (Exception exp)
            {
                Console.WriteLine("Srry m8, this error happened: " + exp.Message);
            }

            Console.WriteLine("Would you like to continue unscrambling words? (Y/y or N/n)");
            string cont = Console.ReadLine().ToUpper();

            while (cont != "Y" && cont != "N")
            {
                Console.WriteLine("Sorry, your choice is incomprehensible, try again.");
                Console.WriteLine("Would you like to continue unscrambling words? (Y/y or N/n)");
                cont = Console.ReadLine().ToUpper();
            }

            while (cont == "Y")
            {
                Console.WriteLine("Enter the scrambled words manually or as a file ---> f - file, m - manual:");

                //?? = null coalesing character
                option = Console.ReadLine() ?? throw new Exception("String is empty");

                while ((option != "f" && option != "F") && (option != "m" && option != "M"))
                {
                    Console.WriteLine("Sorry, that input was not proper, try again.");
                    Console.WriteLine("Enter the scrambled words manually or as a file ---> f - file, m - manual:");
                    option = Console.ReadLine() ?? throw new Exception("String is empty");
                }

                try
                {
                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine("Enter the full path w/the file name:");
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine("Enter the word(s), seperated by a comma:");
                            ExecuteSccrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine("The entered option was not valid, try again.");
                            break;
                    }
                }

                catch (Exception exp)
                {
                    Console.WriteLine("Srry m8, this error happened: " + exp.Message);
                }

                Console.WriteLine("Would you like to continue unscrambling words? (Y/y or N/n)");
                cont = Console.ReadLine().ToUpper();

                while (cont != "Y" && cont != "N")
                {
                    Console.WriteLine("Sorry, your decision is inconclusive, try again.");
                    Console.WriteLine("Would you like to continue unscrambling words? (Y/y or N/n)");
                    cont = Console.ReadLine().ToUpper();
                }

            }

            Environment.Exit(0);

        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.Read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteSccrambledWordsManualEntryScenario()
        {
            string manScramWords = Console.ReadLine();
            string[] splitWords = manScramWords.Split(',');
            string[] scrambledWords = splitWords;
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(Constants.WORDLIST);

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (MatchedWord mw in matchedWords)
                {
                    Console.WriteLine("A match was found for the scrambled word {0}:\t{1}", mw.ScrambledWord, mw.Word);
                }
            }
            else
            {
                Console.WriteLine("The object did not contain any matched words. oop");
            }
        }

    }
 }
