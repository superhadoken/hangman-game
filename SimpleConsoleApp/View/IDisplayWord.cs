using System.Collections.Generic;

namespace SimpleConsoleApp.View
{
    public interface IDisplayWord
    {
        string RenderWordView(IList<KeyValuePair<char, bool>> word);
    }
}
