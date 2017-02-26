using System.Collections.Generic;

namespace SimpleConsoleApp.Models
{
    public class Hangman
    {
        public int GuessesLeft { get; set; }
        public string WordToGuess { get; set; }
        public IList<KeyValuePair<char, bool>> LettersGuessed { get; set; }
        public bool WonGame { get; set; }

        public Hangman()
        {
            GuessesLeft = 11;
            WonGame = false;
        }
    }
}
