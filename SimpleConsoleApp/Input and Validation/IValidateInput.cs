namespace SimpleConsoleApp.Input_and_Validation
{
    public interface IValidateInput
    {
        bool UserInputIsValid(string userInput);
        string CreateInputErrorMessage();
    }
}
