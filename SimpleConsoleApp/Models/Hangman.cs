using System.Collections.Generic;

namespace SimpleConsoleApp.Models
{
    public class Hangman
    {
        public int Counter { get; set; }
        public string WordToGuess { get; set; }
        public IList<KeyValuePair<char, bool>> LettersGuessed { get; set; }
        public IList<char> GuessedLettersIndex { get; set; }

        public Hangman()
        {
            Counter = 0;
        }
    }
}
