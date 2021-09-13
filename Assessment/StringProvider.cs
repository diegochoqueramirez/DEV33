using System.Collections.Generic;

namespace Assessment
{
    public class StringProvider : IElementsProvider<string>
    {
        private static char[] separator = new char[] {' ', ',', '|'};


        public IEnumerable<string> ProcessData(string source)
        {
            return source.Split(separator);
        }
    }
}