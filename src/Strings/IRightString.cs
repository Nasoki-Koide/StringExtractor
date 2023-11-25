using System;

namespace StringExtractors
{
    public interface IRightString
    {
        string Cut(string source);
        string Cut(string source, int startLocation);
    }
}
