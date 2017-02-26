using System.Collections.Generic;
using SimpleConsoleApp.Models;

namespace SimpleConsoleApp.Logic
{
    public class CharMatcher
    {
        public MatchQueryResult CharIsMatchedInWord(IList<KeyValuePair<char, bool>> wordToMatch, char letterToMatch)
        {
            var matchSuccesful = false;
            var iteratedMatchedWord = new List < KeyValuePair<char, bool> >();

            // Find all matching letters in word
            foreach (var letterKeyPair in wordToMatch)
            {
                if (letterKeyPair.Key == letterToMatch)
                {
                    iteratedMatchedWord.Add(new KeyValuePair<char, bool>(letterKeyPair.Key, true));
                    matchSuccesful = true;
                }

                // If no match, leave the result as is
                else iteratedMatchedWord.Add(new KeyValuePair<char, bool>(letterKeyPair.Key, letterKeyPair.Value));
            }

            return new MatchQueryResult
            {
                LettersGuessed = iteratedMatchedWord,
                MatchWasSuccesful = matchSuccesful
            };
        }
    }
}
