using System.Linq;
using Castle.Core.Internal;
using SimpleConsoleApp.Models;

namespace SimpleConsoleApp.Input_and_Validation
{
    public class ValidateInput : IValidateInput
    {
        public bool UserInputIsValid(string userInput)
        {
            return userInput.Length < 2 && !userInput.IsNullOrEmpty();
        }

        public bool UserInputIsUnique(string userInput, Hangman hangmanObject)
        {
            // This is really nasty and could do with cleaning up
            // TODO: Implement check for uppercase and lower case
            return hangmanObject.AlreadyGuessedLetters.ToList().Find(x => x == userInput.ToCharArray()[0]) != userInput.ToCharArray()[0];
        }

        public string CreateInputErrorMessage()
        {
            return "Please enter a single character to guess";
        }

        public string CreateUniqueInputErrorMessage()
        {
            return "Letter already guessed! Please try a new letter";
        }
    }
}
