using System;
using System.Linq;
using SimpleConsoleApp.Data_Access_Layer;
using SimpleConsoleApp.Logic;
using SimpleConsoleApp.View;

namespace SimpleConsoleApp
{
    public class Controller
    {
        static void Main(string[] args)
        {
            // Hello World!
            Console.WriteLine(RenderBanner.CreateBannerForGame());

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
