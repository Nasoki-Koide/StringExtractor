using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal interface IInternalStringType : IStartIndex
    {
        int Skip { get; }
        void SetLeftAndHeadIndex(string source, IndexCollectionBuilder builder);
        void SetRightIndex(string source, IndexCollectionBuilder builder);
    }
}
