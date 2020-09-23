using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler //The purpose of the program is to take scrambled words from the user and find matches that hints to what they actually are
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader(); //Make file reader and word matcher
        private static readonly WordMatcher wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the scrambled words manually or as a file ---> F/f - file, M/m - manual:"); //Prompt the user
            string option = Console.ReadLine().ToUpper() ?? throw new Exception("String is empty"); //Take the input and bring it to uppercase, limit errors

            while (option != "F" && option != "M") //Input validation
            {
                Console.WriteLine("Sorry, your choice is incomprehensible, try again.");
                Console.WriteLine("Enter the scrambled words manually or as a file ---> f - file, m - manual:");
                option = Console.ReadLine().ToUpper() ?? throw new Exception("String is empty");
            }

            try //Try/catch blocks to handle IO exceptions
            {
                switch (option) //Switch block to choose what to do based on user decision
                {
                    case "F": //If the user choose to unscramble words in a file
                        Console.WriteLine("Enter the full path w/the file name:");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M": //If the user choose to unscramble words they put in
                        Console.WriteLine("Enter the word(s), seperated by a comma:");
                        ExecuteSccrambledWordsManualEntryScenario();
                        break;
                    default: //If the user failed to choose either choice
                        Console.WriteLine("The entered option was not valid, try again.");
                        break;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Srry m8, this error happened: " + exp.Message);
            }

            Console.WriteLine("Would you like to continue unscrambling words? (Y/y or N/n)"); //Prompt the user to continue or not
            string cont = Console.ReadLine().ToUpper(); //Take the user's choice and bring it to uppercase

            while (cont != "Y" && cont != "N") //Input validation
            {
                Console.WriteLine("Sorry, your choice is incomprehensible, try again.");
                Console.WriteLine("Would you like to continue unscrambling words? (Y/y or N/n)");
                cont = Console.ReadLine().ToUpper();
            }

            while (cont == "Y") //Loop the program if the user choose to keep going
            {
                Console.WriteLine("Enter the scrambled words manually or as a file ---> f - file, m - manual:");
                option = Console.ReadLine().ToUpper() ?? throw new Exception("String is empty");

                while (option != "F" && option != "M")
                {
                    Console.WriteLine("Sorry, that input was not proper, try again.");
                    Console.WriteLine("Enter the scrambled words manually or as a file ---> f - file, m - manual:");
                    option = Console.ReadLine().ToUpper() ?? throw new Exception("String is empty");
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
            Environment.Exit(0); //End the program and all it's processes if the user choose to stop
        }

        private static void ExecuteScrambledWordsInFileScenario() //Create a method for unscrambling words in a file
        {
            string fileName = Console.ReadLine(); //Take in the file path
            string[] scrambledWords = fileReader.Read(fileName); //Call the FileReader class's Read method to return the file's contents as an array

            DisplayMatchedScrambledWords(scrambledWords); //Call the DisplayMatchedScrambledWords method to show any matches found
        }

        private static void ExecuteSccrambledWordsManualEntryScenario() //Create a method for unscrambling words the user puts in
        {
            string manScramWords = Console.ReadLine(); //Take in the user's scrambled words
            string[] splitWords = manScramWords.Split(','); //Split off the words using the Split method and return them into an array

            DisplayMatchedScrambledWords(splitWords); //Call the DisplayMatchedScrambledWords method to show any matches found
        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords) //Create a method to show the user of any matches found
        {
            string[] wordList = fileReader.Read(Constants.WORDLIST); //Call the FileReader classes's Read method to retreive the word list from the Constants namespace

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList); //Call the WordMatcher classes's Match method to test for any matches

            if (matchedWords.Any()) //If the Match method got any matches
            {
                foreach (MatchedWord matchesFound in matchedWords) //Use a foreach loop to cycle through the matches found
                {
                    Console.WriteLine("A match was found for the scrambled word {0}:\t{1}", matchesFound.ScrambledWord, matchesFound.Word);
                }
            }
            else //If no matches were made
            {
                Console.WriteLine("The object did not contain any matched words. oop");
            }
        }
    }
 }