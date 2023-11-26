using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal interface IInternalLeftString
    {
        void CalculateLeftAndHeadIndex(
            int startIndex,
            string source,
            IndexCollectionBuilder builder);
    }
}
