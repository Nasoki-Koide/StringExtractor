using System;

namespace StringExtractors.Indexes
{
    internal class IndexCollectionBuilder
    {
        public int Left { get; set; }
        public int Right { get; set; }
        public int Head { get; set; }

        public IndexCollection Build() => new IndexCollection(Left, Right, Head);

    }
}
