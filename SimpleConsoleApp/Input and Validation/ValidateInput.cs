using Castle.Core.Internal;

namespace SimpleConsoleApp.Input_and_Validation
{
    public class ValidateInput
    {
        public bool UserInputIsValid(string userInput)
        {
            return userInput.Length < 2 && !userInput.IsNullOrEmpty();
        }

        public string CreateInputErrorMessage()
        {
            return "Please enter a single character to guess";
        }
    }
}
