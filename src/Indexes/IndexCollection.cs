using System;

namespace StringExtractors.Indexes
{
    public class IndexCollection
    {
        internal IndexCollection(int left, int right, int head)
        {
            Left = left;
            Right = right;
            Head = head;
        }

        public int Left { get; }
        public int Right { get; }
        public int Head { get; }
    }
}
