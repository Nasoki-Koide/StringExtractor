using System;

namespace StringExtractors.Indexes
{
    public class IndexCollection
    {
        internal IndexCollection(int? left, int? right, int? head)
        {
            Left = left;
            Right = right;
            Head = head;
        }

        public int? Left { get; }
        public int? Right { get; }
        public int? Head { get; }

        public string ExtractFrom(string source)
        {
            if (Head is null)
                return string.Empty;

            if (Right is null)
                return source.Substring(Head.Value);

            return source.Substring(Head.Value, Right.Value - Head.Value);
        }
    }
}
