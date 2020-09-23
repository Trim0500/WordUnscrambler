using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordUnscrambler
{
    class FileReader //This class will read the contents of a file and put it into an array to be used by the driver class
    {
        public string[] Read(string filename) //Create the read method w/a filename as an argument
        {
            string[] words = null; //Create the global words variable

            try //Try/catch blocks to handle IO exceptions
            {
                using (StreamReader readFileContents = new StreamReader(@filename)) //Open a file to use and implicitly call the Dispose method to close the file
                {
                    words = File.ReadAllLines(@filename); //Read the conntents
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Sorry, the file could not be found: " + exp.Message);
            }
            return words; //Method returns a string array of words
        }
    }
}
