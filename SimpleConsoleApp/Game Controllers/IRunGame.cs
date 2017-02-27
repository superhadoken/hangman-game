using System;
using System.Linq;
using SimpleConsoleApp.Data_Access_Layer;
using SimpleConsoleApp.Logic;
using SimpleConsoleApp.Models;
using SimpleConsoleApp.View;

namespace SimpleConsoleApp.Game_Controllers
{
    public interface IRunGame
    {
        void SetupAndStartNewGame();
    }

    public class RunGame : IRunGame
    {
        private readonly IRenderBanner _renderBanner;
        private readonly IFileReader _fileReader;
        private readonly IRandomWordSelector _randomWordSelector;
        private readonly IAssembleGuessedLetters _assembleGuessedLetters;
        private readonly IDisplayWord _displayWord;
        private readonly IMainGame _mainGame;
        private readonly IResultsScreen _resultsScreen;

        public RunGame(IRenderBanner renderBanner, 
            IFileReader fileReader, 
            IRandomWordSelector randomWordSelector,
            IAssembleGuessedLetters assembleGuessedLetters,
            IDisplayWord displayWord,
            IMainGame mainGame,
            IResultsScreen resultsScreen)
        {
            _renderBanner = renderBanner;
            _fileReader = fileReader;
            _randomWordSelector = randomWordSelector;
            _assembleGuessedLetters = assembleGuessedLetters;
            _displayWord = displayWord;
            _mainGame = mainGame;
            _resultsScreen = resultsScreen;
        }

        public void SetupAndStartNewGame()
        {
            Console.WriteLine(_renderBanner.CreateBannerForGame());

            // Load the Dictionary
            var wordList = _fileReader.LoadDictionary().ToList();

            // Select and print random word
            var randomWord = _randomWordSelector.SelectRandomWordFromDictionary(wordList);

            Console.WriteLine("Lets play Hangman!");

            // Assemble the Hangman Object
            var hangmanObject = new Hangman
            {
                WordToGuess = randomWord,
                LettersGuessed = _assembleGuessedLetters.AssembleTheGuessedLetters(randomWord)
            };

            Console.WriteLine("Word to guess: {0}", _displayWord.RenderWordView(hangmanObject.LettersGuessed));

            // Perform Hangman Logic
            _mainGame.Run(hangmanObject);

            Console.Clear();

            // Results Screen
            _resultsScreen.RunResults(hangmanObject);
            System.Threading.Thread.Sleep(3000);
        }
    }
}
