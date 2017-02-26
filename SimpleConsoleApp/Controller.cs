using System;
using System.Linq;
using System.Reflection;
using Ninject;
using SimpleConsoleApp.Data_Access_Layer;
using SimpleConsoleApp.Input_and_Validation;
using SimpleConsoleApp.Logic;
using SimpleConsoleApp.Models;
using SimpleConsoleApp.View;

namespace SimpleConsoleApp
{
    public class Controller
    {
        static void Main(string[] args)
        {
            var randomWordSelctor = new RandomWordSelector();
            var letterFormatAssembler = new AssembleGuessedLetters();
            var wordRenderer = new DisplayWord();
            var hangmanDisplay = new RenderHangman();
            var banners = new RenderBanner();
            var kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());
            var wordDictionaryLoader = kernal.Get<IFileReader>();

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
            MainGame(hangmanObject);
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

        private static void MainGame(Hangman hangmanObject)
        {
            var wordRenderer = new DisplayWord();
            var inputValidator = new ValidateInput();
            var charMatcher = new CharMatcher();
            var hangmanDisplay = new RenderHangman();

            while (hangmanObject.GuessesLeft > 0 && !hangmanObject.WonGame)
            {
                var userInput = Console.ReadLine(); // Wait for user input

                if (inputValidator.UserInputIsValid(userInput))
                {
                    Console.Clear();
                    var result = charMatcher.CharIsMatchedInWord(hangmanObject.LettersGuessed, userInput.ToCharArray()[0]);
                    hangmanObject.LettersGuessed = result.LettersGuessed;

                    if (result.MatchWasSuccesful)
                    {
                        Console.WriteLine(hangmanDisplay.SwitchAndDisplayHangmanImage(hangmanObject.GuessesLeft));
                        Console.WriteLine("Word to guess: {0}",
                            wordRenderer.RenderWordView(hangmanObject.LettersGuessed));
                        if (result.GameIsWon)
                        {
                            hangmanObject.WonGame = result.GameIsWon;
                            break;
                        }
                    }
                    else
                    {
                        hangmanObject.GuessesLeft--;
                        Console.WriteLine(hangmanDisplay.SwitchAndDisplayHangmanImage(hangmanObject.GuessesLeft));
                        Console.WriteLine("Word to guess: {0}",
                            wordRenderer.RenderWordView(hangmanObject.LettersGuessed));

                        // Pause screen before game over
                        if (hangmanObject.GuessesLeft == 0)
                            System.Threading.Thread.Sleep(3000);
                    }
                    MainGame(hangmanObject);
                }
                else Console.WriteLine(inputValidator.CreateInputErrorMessage());
            }
        }
    }
}
