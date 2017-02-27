using SimpleConsoleApp.Models;

namespace SimpleConsoleApp.Input_and_Validation
{
    public interface IValidateInput
    {
        bool UserInputIsValid(string userInput);
        string CreateInputErrorMessage();

        bool UserInputIsUnique(string userInput, Hangman hangmanObject);
        string CreateUniqueInputErrorMessage();
    }
}
