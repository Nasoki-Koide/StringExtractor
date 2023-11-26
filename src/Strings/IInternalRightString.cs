using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal interface IInternalRightString
    {
        void CalculateRightIndex(
            int startIndex,
            string source,
            IndexCollectionBuilder builder);
    }
}
