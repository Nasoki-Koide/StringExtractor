using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings.InternalStringTypes
{
    internal interface IInternalStringType : IStartIndex
    {
        int Skip { get; }
        void SetLeftAndHeadIndex(string source, IndexCollectionBuilder builder);
        void SetRightIndex(string source, IndexCollectionBuilder builder);
    }
}
