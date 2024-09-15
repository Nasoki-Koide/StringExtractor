using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal interface IIndexSetter
    {
        void SetIndex(
            string source,
            IndexCollectionBuilder builder);
    }
}
