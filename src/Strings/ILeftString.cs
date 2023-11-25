using System;

namespace StringExtractors
{
    public interface ILeftString
    {
        string Cut(string source);
        string Cut(string source, int startLocation);
    }
}
