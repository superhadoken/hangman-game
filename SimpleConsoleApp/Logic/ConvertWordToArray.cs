namespace SimpleConsoleApp.Logic
{
    public class ConvertWordToArray : IConvertWordToArray
    {
        public char[] ConvertertStringToCharArray(string word)
        {
            return word.ToCharArray();
        }
    }
}
