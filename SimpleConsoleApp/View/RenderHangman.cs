namespace SimpleConsoleApp.View
{
    public class RenderHangman : IRenderHangman
    {
        public string SwitchAndDisplayHangmanImage(int guessRemaining)
        {
            switch (guessRemaining)
            {
                case 0:
                    return @"
      _______
     |/      |
     |      (_)
     |      \|/
     |       |
     |      / \
     |
    _|___";
                case 1:
                    return @"
      _______
     |/      |
     |      (_)
     |      \|/
     |       |
     |        \
     |
    _|___";
                case 2:
                    return @"
      _______
     |/      |
     |      (_)
     |      \|/
     |       |
     |      
     |
    _|___";
                case 3:
                    return @"
      _______
     |/      |
     |      (_)
     |       |/
     |       |
     |      
     |
    _|___";
                case 4:
                    return @"
      _______
     |/      |
     |      (_)
     |       |
     |       |
     |      
     |
    _|___";
                case 5:
                    return @"
      _______
     |/      |
     |      (_)
     |       |
     |       
     |      
     |
    _|___";
                case 6:
                    return @"
      _______
     |/      |
     |      (_)
     |       
     |       
     |      
     |
    _|___";
                case 7:
                    return @"
      _______
     |/      
     |      
     |       
     |       
     |      
     |
    _|___";
                case 8:
                    return @"
      _______
     |      
     |      
     |       
     |       
     |      
     |
    _|___";
                case 9:
                    return @"
      
     |      
     |      
     |       
     |       
     |      
     |
    _|___";
                case 10:
                    return @"
      
           
           
            
            
           
     
    _____";
                case 11:
                    return @"
      
           
           
            
            
           
     
	 ";
                default:
                    return "Error in application assessing guesses left";
            }
        }

        public string RenderGameOver()
        {
            return @"
                            GAME OVER

             .... NO! ...                  ... MNO! ...
           ..... MNO!! ...................... MNNOO! ...
         ..... MMNO! ......................... MNNOO!! .
        .... MNOONNOO!   MMMMMMMMMMPPPOII!   MNNO!!!! .
         ... !O! NNO! MMMMMMMMMMMMMPPPOOOII!! NO! ....
            ...... ! MMMMMMMMMMMMMPPPPOOOOIII! ! ...
           ........ MMMMMMMMMMMMPPPPPOOOOOOII!! .....
           ........ MMMMMOOOOOOPPPPPPPPOOOOMII! ...
            ....... MMMMM..    OPPMMP    .,OMI! ....
             ...... MMMM::   o.,OPMP,.o   ::I!! ...
                 .... NNM:::.,,OOPM!P,.::::!! ....
                  .. MMNNNNNOOOOPMO!!IIPPO!!O! .....
                 ... MMMMMNNNNOO:!!:!!IPPPPOO! ....
                   .. MMMMMNNOOMMNNIIIPPPOO!! ......
                  ...... MMMONNMMNNNIIIOO!..........
               ....... MN MOMMMNNNIIIIIO! OO ..........
            ......... MNO! IiiiiiiiiiiiI OOOO ...........
          ...... NNN.MNO! . O!!!!!!!!!O . OONO NO! ........
           .... MNNNNNO! ...OOOOOOOOOOO .  MMNNON!........
           ...... MNNNNO! .. PPPPPPPPP .. MMNON!........
              ...... OO! ................. ON! .......
                 ................................
        
                        Thank you for playing!
";
        }
    }
}
