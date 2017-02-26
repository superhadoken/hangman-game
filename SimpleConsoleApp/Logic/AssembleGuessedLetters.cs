using System.Collections.Generic;

namespace SimpleConsoleApp.Logic
{
    public class AssembleGuessedLetters : IAssembleGuessedLetters
    {
        public IList<KeyValuePair<char, bool>> AssembleTheGuessedLetters(string word)
        {
            var lettersGuessed = new List<KeyValuePair<char, bool>>();
            foreach (var letter in word.ToCharArray())
            {
                lettersGuessed.Add(new KeyValuePair<char, bool>(letter, false));
            }

            return lettersGuessed;
        }
    }
}
