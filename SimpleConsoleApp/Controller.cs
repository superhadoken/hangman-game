using System;
using System.Linq;
using SimpleConsoleApp.Data_Access_Layer;
using SimpleConsoleApp.Logic;

namespace SimpleConsoleApp
{
    public class Controller
    {
        static void Main(string[] args)
        {
            // Hello World!
            Console.WriteLine("Hello World");

            // Load the Dictionary
            var wordDictionary = FileReader.LoadDictionary().ToList();

            // Spit out all of the available words
            foreach (var entry in wordDictionary)
            {
                Console.WriteLine(entry);
            }

            // Select and print random word
            var randomWord = RandomWordSelector.SelectRandomWordFromDictionary(wordDictionary);
            Console.WriteLine(randomWord);
        }
    }
}
