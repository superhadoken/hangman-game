using System;
using System.Linq;
using System.Reflection;
using Ninject;
using SimpleConsoleApp.Data_Access_Layer;
using SimpleConsoleApp.Input_and_Validation;
using SimpleConsoleApp.Logic;
using SimpleConsoleApp.Models;
using SimpleConsoleApp.View;

namespace SimpleConsoleApp.Game_Controllers
{
    public class Controller
    {
        static void Main(string[] args)
        {
            var randomWordSelctor = new RandomWordSelector();
            var letterFormatAssembler = new AssembleGuessedLetters();

            var kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());

            var wordDictionaryLoader = kernal.Get<IFileReader>();
            var wordRenderer = kernal.Get<IDisplayWord>();
            var validInput = kernal.Get<IValidateInput>();
            var charMatcher = kernal.Get<ICharMatcher>();
            var hangmanDisplay = kernal.Get<IRenderHangman>();
            var banners = kernal.Get<IRenderBanner>();

            // Hello World!
            Console.WriteLine(banners.CreateBannerForGame());

            // Load the Dictionary
            var wordList = wordDictionaryLoader.LoadDictionary().ToList();

            // Select and print random word
            var randomWord = randomWordSelctor.SelectRandomWordFromDictionary(wordList);

            Console.WriteLine("Lets play Hangman!");

            // Assemble the Hangman Object
            var hangmanObject = new Hangman
            {
                WordToGuess = randomWord,
                LettersGuessed = letterFormatAssembler.AssembleTheGuessedLetters(randomWord)
            };

            Console.WriteLine("Word to guess: {0}", wordRenderer.RenderWordView(hangmanObject.LettersGuessed));

            // Perform Hangman Logic
            var mainGame = new MainGame(wordRenderer, validInput, charMatcher, hangmanDisplay);
            mainGame.Run(hangmanObject);
            
            Console.Clear();

            // Results Screen
            var resultsScreen = new ResultsScreen(banners, hangmanDisplay);
            resultsScreen.RunResults(hangmanObject);
            System.Threading.Thread.Sleep(3000);
            Console.ReadKey();
        }
    }
}
