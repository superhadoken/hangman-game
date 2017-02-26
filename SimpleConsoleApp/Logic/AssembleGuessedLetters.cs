using System.Collections.Generic;

namespace SimpleConsoleApp.Logic
{
    public class AssembleGuessedLetters
    {
        public IDictionary<char, bool> AssembleTheGuessedLetters(string word)
        {
            var lettersGuessed = new Dictionary<char, bool>();
            foreach (var letter in word.ToCharArray())
            {
                lettersGuessed.Add(letter, false);
            }

            return lettersGuessed;
        }
    }
}
