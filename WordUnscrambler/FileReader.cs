using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordUnscrambler
{
    class FileReader
    {

        public string[] Read(string filename)
        {
            string[] words = null;
            try
            {
                using (StreamReader readFileContents = new StreamReader(@filename))
                {
                    words = File.ReadAllLines(@filename);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Sorry, the file could not be found: " + exp.Message);
            }
            return words;
        }

    }
}
