using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class InternalRightString : IInternalRightString
    {
        public InternalRightString(string value, SearchDirection searchDirection, int skip)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
            }

            Value = value;
            SearchDirection = searchDirection;
            Skip = skip;
        }

        public string Value { get; }
        public SearchDirection SearchDirection { get; }
        public int Skip { get; }

        public void CalculateRightIndex(
            int startIndex,
            string source,
            IndexCollectionBuilder builder)
        {
            int right = 0;
            for (var i = 0; i <= Skip; i++)
            {
                switch (SearchDirection)
                {
                    case SearchDirection.Forward:
                        right = source.IndexOf(Value, startIndex);

                        if (right == -1)
                            throw new InvalidOperationException();

                        startIndex = right + 1;
                        break;
                    case SearchDirection.Backward:
                        right = source.LastIndexOf(Value, startIndex);

                        if (right == -1)
                            throw new InvalidOperationException();

                        startIndex = right - 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(SearchDirection));
                }
            }

            builder.Right = right;
        }
    }
}
