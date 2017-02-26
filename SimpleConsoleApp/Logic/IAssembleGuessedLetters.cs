using System.Collections.Generic;

namespace SimpleConsoleApp.Logic
{
    public interface IAssembleGuessedLetters
    {
        IList<KeyValuePair<char, bool>> AssembleTheGuessedLetters(string word);
    }
}
