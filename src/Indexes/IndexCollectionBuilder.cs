using System;

namespace StringExtractors.Indexes
{
    internal class IndexCollectionBuilder
    {
        public int? Left { get; set; }
        public int? Right { get; set; }
        public int? Head { get; set; }

        public IndexCollection Build()
        {
            // Head is Left + length of LeftString.
            // So, this condition means there is no string between Left and Right.
            if (Head == Right)
                Head = null;

            return new IndexCollection(Left, Right, Head);
        }

    }
}
