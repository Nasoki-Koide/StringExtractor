using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class NullInternalRightString : IInternalRightString
    {
        public void CalculateRightIndex(int startIndex, string source, IndexCollectionBuilder builder)
        {
            builder.Right = null;
        }
    }
}
