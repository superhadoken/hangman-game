using System.Collections.Generic;

namespace SimpleConsoleApp.View
{
    public class DisplayWord
    {
        public string RenderWordView(IList<KeyValuePair<char, bool>> word)
        {
            var view = "";
            foreach (var letterPair in word)
            {
                if (letterPair.Value)
                    view += letterPair.Key;
                else view += "_ ";
            }

            return view;
        }
    }
}
