namespace SimpleConsoleApp.Logic
{
    public class GuessCounter
    {
        private int counter = 0;
        private int maxAmountOfGuesses = 7;

        private bool IsGameOver()
        {
            return counter < maxAmountOfGuesses;
        }

        private void IncrementCounter()
        {
            counter++;
        }

        private void ResetCounter()
        {
            counter = 0;
        }
    }
}
