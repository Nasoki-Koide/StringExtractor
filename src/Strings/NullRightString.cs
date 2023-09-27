using System;

namespace StringExtractors.Strings
{
    public class NullRightString : IRightString
    {
        public string Cut(string source)
        {
            return source;
        }
    }
}
