using System;
using SimpleConsoleApp.Models;
using SimpleConsoleApp.View;

namespace SimpleConsoleApp.Game_Controllers
{
    public interface IResultsScreen
    {
        void RunResults(Hangman hangmanObject);
    }

    public class ResultsScreen : IResultsScreen
    {
        private readonly IRenderBanner _banners;
        private readonly IRenderHangman _hangmanDisplay;

        public ResultsScreen(IRenderBanner banners, IRenderHangman hangmanDisplay)
        {
            _banners = banners;
            _hangmanDisplay = hangmanDisplay;
        }

        public void RunResults(Hangman hangmanObject)
        {
            if (hangmanObject.WonGame)
            {
                Console.WriteLine(_banners.YouWinBanner());
                Console.WriteLine("                     You guessed the word in {0} guesses",
                    new Hangman().GuessesLeft - hangmanObject.GuessesLeft);
                Console.WriteLine("                     Thank you for playing");
            }
            else
            {
                Console.WriteLine("The word was: {0}", hangmanObject.WordToGuess);
                Console.WriteLine(_hangmanDisplay.RenderGameOver());
            }
        }
    }
}
