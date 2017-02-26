using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleConsoleApp.Data_Access_Layer
{
    public class FileReader
    {
        public FileReader()
        {

        }

        public static IEnumerable<string> LoadDictionary()
        {
            var wordArray = new List<string>();

            foreach (var line in File.ReadLines(@"C:\Users\Mo Mutlak\Documents\Visual Studio 2013\Projects\hangman-game\SimpleConsoleApp\Dictionary\dictionary.txt", 
                Encoding.UTF8))
            {
                wordArray.Add(line);
            }

            return wordArray;
        }
    }
}
