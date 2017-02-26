using System.Collections.Generic;

namespace SimpleConsoleApp.Data_Access_Layer
{
    public interface IFileReader
    {
        IEnumerable<string> LoadDictionary();
    }
}
