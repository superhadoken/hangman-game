using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SimpleConsoleApp.Data_Access_Layer
{
    public class FileReader : IFileReader
    {
        public IEnumerable<string> LoadDictionary()
        {
            var wordArray = new List<string>();

            try
            {
                var loadedFile = File.ReadLines("Dictionary\\dictionary.txt", Encoding.UTF8).ToList();

                foreach (var line in loadedFile)
                {
                    wordArray.Add(line);
                }

                return wordArray;
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine("Could not find a data dictionary to read!");
            }

            return wordArray;
        }
    }
}
