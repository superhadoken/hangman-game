using System.Reflection;
using Ninject;

namespace SimpleConsoleApp.Game_Controllers
{
    public class Controller
    {
        static void Main(string[] args)
        {
            var kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());

            var runGame = kernal.Get<IRunGame>();
            runGame.SetupAndStartNewGame();
        }
    }
}
