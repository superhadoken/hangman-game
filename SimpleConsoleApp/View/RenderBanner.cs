namespace SimpleConsoleApp.View
{
    public class RenderBanner : IRenderBanner
    {
        public string CreateBannerForGame()
        {
            return @"
                      _                                             
                     | |                                            
                     | |__   __ _ _ __   __ _ _ __ ___   __ _ _ __  
                     | '_ \ / _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
                     | | | | (_| | | | | (_| | | | | | | (_| | | | |
                     |_| |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|
                                         __/ |                      
                                        |___/                       
                     by Mo Mutlak 2017";
        }

        public string YouWinBanner()
        {
            return @"
                      _                     _                         
                     (_|   |               (_|   |   |_/o            |
                       |   |  __             |   |   |      _  _     |
                       |   | /  \_|   |      |   |   |  |  / |/ |    |
                        \_/|/\__/  \_/|_/     \_/ \_/   |_/  |  |_/  o
                          /|                                          
                          \|
";
        }
    }
}
