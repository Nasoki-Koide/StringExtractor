using System;

namespace StringExtractors.Indexes
{
    /// <summary>
    /// Indexes of left/right string and extracted string in source.
    /// </summary>
    public class IndexCollection
    {
        internal IndexCollection(int? left, int? right, int? head)
        {
            Left = left;
            Right = right;
            Head = head;
        }

        /// <summary>
        /// Zero-based index of <c>LeftString</c> in source.
        /// </summary>
        public int? Left { get; }

        /// <summary>
        /// Zero-based index of <c>RightString</c> in source.
        /// </summary>
        public int? Right { get; }

        /// <summary>
        /// Zero-based index of extracted string in source.
        /// </summary>
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
