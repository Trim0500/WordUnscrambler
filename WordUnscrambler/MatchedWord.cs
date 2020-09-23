using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    struct MatchedWord //Create a struct to store the scrambled and comparable words to store as the WordMatcher class uses them
    {
        public string ScrambledWord { get; set; } //Create the ScrambledWord variable w/getter & setter methods
        public string Word { get; set; } //Create the Word variable w/getter & setter methods
    }
}
