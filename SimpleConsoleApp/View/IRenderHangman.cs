namespace SimpleConsoleApp.View
{
    public interface IRenderHangman
    {
        string SwitchAndDisplayHangmanImage(int guessRemaining);
        string RenderGameOver();
    }
}
