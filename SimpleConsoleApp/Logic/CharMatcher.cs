using System.Collections.Generic;
using SimpleConsoleApp.Models;

namespace SimpleConsoleApp.Logic
{
    public class CharMatcher : ICharMatcher
    {
        public MatchQueryResult CharIsMatchedInWord(IList<KeyValuePair<char, bool>> wordToMatch, char letterToMatch)
        {
            var matchSuccesful = false;
            var matchedLettersCount = 0;
            var iteratedMatchedWord = new List < KeyValuePair<char, bool> >();

            // Find all matching letters in word
            foreach (var letterKeyPair in wordToMatch)
            {
                if (letterKeyPair.Key == letterToMatch)
                {
                    iteratedMatchedWord.Add(new KeyValuePair<char, bool>(letterKeyPair.Key, true));
                    matchSuccesful = true;
                    matchedLettersCount++;
                }

                // If no match, leave the result as is
                else
                {
                    iteratedMatchedWord.Add(new KeyValuePair<char, bool>(letterKeyPair.Key, letterKeyPair.Value));

                    if (letterKeyPair.Value)
                        matchedLettersCount++;
                }
            }

            return new MatchQueryResult
            {
                LettersGuessed = iteratedMatchedWord,
                MatchWasSuccesful = matchSuccesful,
                GameIsWon = IsGameWon(matchedLettersCount, wordToMatch.Count)
            };
        }

        private bool IsGameWon(int matchedLetters, int lengthOfWord)
        {
            return matchedLetters == lengthOfWord;
        }
    }
}
