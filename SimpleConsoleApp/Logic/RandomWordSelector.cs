using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleConsoleApp.Logic
{
    public class RandomWordSelector
    {
        public string SelectRandomWordFromDictionary(IList<string> dictionary)
        {
            var maxDictionaryIndex = dictionary.Count() - 1;

            Random rng = new Random();
            var randomIndex = rng.Next(0, maxDictionaryIndex);
            return dictionary[randomIndex];
        }
    }
}
