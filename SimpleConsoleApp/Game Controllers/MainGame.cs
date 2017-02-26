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
                    var result = _charMatcher.CharIsMatchedInWord(hangmanObject.LettersGuessed, userInput.ToCharArray()[0]);
                    hangmanObject.LettersGuessed = result.LettersGuessed;

                    if (result.MatchWasSuccesful)
                    {
                        Console.WriteLine(_renderHangman.SwitchAndDisplayHangmanImage(hangmanObject.GuessesLeft));
                        Console.WriteLine("Word to guess: {0}",
                            _displayWord.RenderWordView(hangmanObject.LettersGuessed));
                        if (result.GameIsWon)
                        {
                            hangmanObject.WonGame = result.GameIsWon;
                            break;
                        }
                    }
                    else
                    {
                        hangmanObject.GuessesLeft--;
                        Console.WriteLine(_renderHangman.SwitchAndDisplayHangmanImage(hangmanObject.GuessesLeft));
                        Console.WriteLine("Word to guess: {0}",
                            _displayWord.RenderWordView(hangmanObject.LettersGuessed));

                        // Pause screen before game over
                        if (hangmanObject.GuessesLeft == 0)
                            System.Threading.Thread.Sleep(3000);
                    }
                    Run(hangmanObject);
                }
                else Console.WriteLine(_validateInput.CreateInputErrorMessage());
            }
        }
    }
}
