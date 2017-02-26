using System.Collections.Generic;
using SimpleConsoleApp.Models;

namespace SimpleConsoleApp.Logic
{
    public interface ICharMatcher
    {
        MatchQueryResult CharIsMatchedInWord(IList<KeyValuePair<char, bool>> wordToMatch, char letterToMatch);
    }
}
