using System;
using SimpleConsoleApp.Input_and_Validation;
using SimpleConsoleApp.Logic;
using SimpleConsoleApp.Models;
using SimpleConsoleApp.View;

namespace SimpleConsoleApp.Game_Controllers
{
    public class MainGame : IMainGame
    {
        private readonly IDisplayWord _displayWord;
        private readonly IValidateInput _validateInput;
        private readonly ICharMatcher _charMatcher;
        private readonly IRenderHangman _renderHangman;

        public MainGame(IDisplayWord displayWord, IValidateInput validateInput, ICharMatcher charMatcher, IRenderHangman renderHangman)
        {
            _displayWord = displayWord;
            _validateInput = validateInput;
            _charMatcher = charMatcher;
            _renderHangman = renderHangman;
        }

        public void Run(Hangman hangmanObject)
        {
            while (hangmanObject.GuessesLeft > 0 && !hangmanObject.WonGame)
            {
                var userInput = Console.ReadLine(); // Wait for user input

                if (_validateInput.UserInputIsValid(userInput))
                {
                    Console.Clear();
                    hangmanObject.AlreadyGuessedLetters.Add(Convert.ToChar(userInput));
                    var result = _charMatcher.CharIsMatchedInWord(hangmanObject.LettersInWordSplit, userInput.ToCharArray()[0]);
                    hangmanObject.LettersInWordSplit = result.LettersGuessed;

                    if (result.MatchWasSuccesful)
                    {
                        CreateView(hangmanObject);
                        if (result.GameIsWon)
                        {
                            hangmanObject.WonGame = result.GameIsWon;
                            break;
                        }
                    }
                    else
                    {
                        hangmanObject.GuessesLeft--;
                        CreateView(hangmanObject);
                    }
                    Run(hangmanObject);
                }
                else Console.WriteLine(_validateInput.CreateInputErrorMessage());
            }
        }

        private void CreateView(Hangman hangmanObject)
        {
            Console.WriteLine(_renderHangman.SwitchAndDisplayHangmanImage(hangmanObject.GuessesLeft));
            Console.WriteLine("Word to guess: {0}",
                _displayWord.RenderWordView(hangmanObject.LettersInWordSplit));
            Console.WriteLine("Already guessed: {0}", string.Join(", ", hangmanObject.AlreadyGuessedLetters));
        }
    }
}
