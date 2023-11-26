using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal interface IInternalStringType
    {
        int Skip { get; }
        SearchDirection SearchDirection { get; }
        void SetLeftAndHeadIndex(string source, int startIndex, IndexCollectionBuilder builder);
        void SetRightIndex(string source, int startIndex, IndexCollectionBuilder builder);
    }
}
