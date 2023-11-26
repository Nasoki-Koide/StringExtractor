using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class NullInternalStringType : IInternalStringType
    {
        // None of properties is used. 
        public int Skip { get; }

        public SearchDirection SearchDirection { get; }

        public int StartIndex { get; set; }

        public void SetLeftAndHeadIndex(string source, IndexCollectionBuilder builder)
        {
            builder.Left = null;
            builder.Head = 0;
        }

        public void SetRightIndex(string source, IndexCollectionBuilder builder)
        {
            builder.Right = null;
        }
    }
}
