using System.Collections.Generic;

namespace SimpleConsoleApp.Logic
{
    public class CharMatcher
    {
        public CharMatcher()
        {
            
        }

        public bool CharIsMatchedInWord(IList<KeyValuePair<char, bool>> wordToMatch, char letterToMatch)
        {
            foreach (var letterKeyPair in wordToMatch)
            {
                if (letterKeyPair.Key == letterToMatch)
                {
                    letterKeyPair.Value = true;
                }
            }
        }
    }
}
