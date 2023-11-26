using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class NullInternalLeftString : IInternalLeftString
    {
        public void CalculateLeftAndHeadIndex(int startIndex, string source, IndexCollectionBuilder builder)
        {
            builder.Left = null;
            builder.Head = 0;
        }
    }
}
