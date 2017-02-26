using System.Collections.Generic;

namespace SimpleConsoleApp.Logic
{
    public interface IRandomWordSelector
    {
        string SelectRandomWordFromDictionary(IList<string> dictionary);
    }
}
