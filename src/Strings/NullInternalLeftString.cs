using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class NullInternalLeftString : IIndexSetter, ILeftStartIndex
    {
        public SearchDirection SearchDirection => SearchDirection.Forward;

        public int LengthOfValue => 0;

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
            builder.Left = null;
            builder.Head = 0;
        }
    }
}
