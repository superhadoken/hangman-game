using System.Collections.Generic;

namespace SimpleConsoleApp.Models
{
    public class MatchQueryResult
    {
        public IList<KeyValuePair<char, bool>> LettersGuessed { get; set; }
        public bool MatchWasSuccesful { get; set; }
        public bool GameIsWon { get; set; }
    }
}
