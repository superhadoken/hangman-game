using Ninject.Modules;
using SimpleConsoleApp.Data_Access_Layer;
using SimpleConsoleApp.Game_Controllers;
using SimpleConsoleApp.Input_and_Validation;
using SimpleConsoleApp.Logic;
using SimpleConsoleApp.View;

namespace SimpleConsoleApp
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            // Data Access Layer
            Bind<IFileReader>().To<FileReader>();

            // Input
            Bind<IValidateInput>().To<ValidateInput>();

            // View
            Bind<IDisplayWord>().To<DisplayWord>();
            Bind<IRenderBanner>().To<RenderBanner>();
            Bind<IRenderHangman>().To<RenderHangman>();

            // Logic Layer
            Bind<IAssembleGuessedLetters>().To<AssembleGuessedLetters>();
            Bind<ICharMatcher>().To<CharMatcher>();
            Bind<IConvertWordToArray>().To<ConvertWordToArray>();
            Bind<IRandomWordSelector>().To<RandomWordSelector>();

            // Game Controllers
            Bind<IMainGame>().To<MainGame>();
        }
    }
}
