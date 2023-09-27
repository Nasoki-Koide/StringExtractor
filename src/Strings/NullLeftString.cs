using System;

namespace StringExtractors.Strings
{
    public class NullLeftString : ILeftString
    {
        public string Cut(string source)
        {
            return source;
        }
    }
}
