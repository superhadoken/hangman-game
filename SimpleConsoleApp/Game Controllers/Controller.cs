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
            var banners = new RenderBanner();

            var kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());

            var wordDictionaryLoader = kernal.Get<IFileReader>();
            var wordRenderer = kernal.Get<IDisplayWord>();
            var validInput = kernal.Get<IValidateInput>();
            var charMatcher = kernal.Get<ICharMatcher>();
            var hangmanDisplay = kernal.Get<IRenderHangman>();

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
            if (hangmanObject.WonGame)
            {
                Console.WriteLine(banners.YouWinBanner());
                Console.WriteLine("                     You guessed the word in {0} guesses", new Hangman().GuessesLeft - hangmanObject.GuessesLeft);
                Console.WriteLine("                     Thank you for playing");
            }
            else Console.WriteLine(hangmanDisplay.RenderGameOver());
            Console.ReadKey();
        }
    }
}
