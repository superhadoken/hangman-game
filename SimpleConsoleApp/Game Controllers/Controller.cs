using System;
using System.Linq;
using System.Reflection;
using Ninject;
using SimpleConsoleApp.Data_Access_Layer;
using SimpleConsoleApp.Input_and_Validation;
using SimpleConsoleApp.Logic;
using SimpleConsoleApp.Models;
using SimpleConsoleApp.View;

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
            
            Console.ReadKey();
        }
    }
}
