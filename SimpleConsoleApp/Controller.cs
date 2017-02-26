using System;
using System.Linq;
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
            var wordDictionaryLoader = new FileReader();

            // Hello World!
            Console.WriteLine(RenderBanner.CreateBannerForGame());

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

            // Perform Hangman Logic
            MainGame(hangmanObject);
        }

        private static void MainGame(Hangman hangmanObject)
        {
            var wordRenderer = new DisplayWord();
            var inputValidator = new ValidateInput();
            var charMatcher = new CharMatcher();
            var hangmanDisplay = new RenderHangman();

            Console.WriteLine("Word to guess: {0}", wordRenderer.RenderWordView(hangmanObject.LettersGuessed));
            while (hangmanObject.GuessesLeft > 0)
            {

                var userInput = Console.ReadLine(); // Wait for user input

                if (inputValidator.UserInputIsValid(userInput))
                {
                    Console.Clear();
                    var result = charMatcher.CharIsMatchedInWord(hangmanObject.LettersGuessed, userInput.ToCharArray()[0]);
                    hangmanObject.LettersGuessed = result.LettersGuessed;

                    if (result.MatchWasSuccesful)
                        Console.WriteLine("Word to guess: {0}", wordRenderer.RenderWordView(hangmanObject.LettersGuessed));
                    else
                    {
                        hangmanObject.GuessesLeft--;
                        Console.WriteLine(hangmanDisplay.SwitchAndDisplayHangmanImage(hangmanObject.GuessesLeft));
                        Console.WriteLine("Word to guess: {0}", wordRenderer.RenderWordView(hangmanObject.LettersGuessed));
                    }
                    MainGame(hangmanObject);
                }
                else Console.WriteLine(inputValidator.CreateInputErrorMessage());
            }
            
            Console.WriteLine(hangmanDisplay.RenderGameOver());
        }
    }
}
