using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal interface IStartIndex
    {
        SearchDirection SearchDirection { get; }

        int StartIndex { get; set; }
    }
}
