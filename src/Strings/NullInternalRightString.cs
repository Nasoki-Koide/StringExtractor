using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class NullInternalRightString : IIndexSetter, IRightStartIndex
    {
        public SearchDirection SearchDirection => SearchDirection.Forward;

        public int StartIndex
        {
            get => 0;
            set
            {
                // do Nothing
            }
        }

        public void SetIndex(string source, IndexCollectionBuilder builder)
        {
            builder.Right = null;
        }
    }
}
