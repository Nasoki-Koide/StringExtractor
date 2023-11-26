using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class NormalInternalStringType : IInternalStringType
    {
        public NormalInternalStringType(
            string value,
            int skip,
            SearchDirection searchDirection,
            StringComparison stringComparison)
        {
            Value = value;
            Skip = skip;
            SearchDirection = searchDirection;
            StringComparison = stringComparison;
        }

        public string Value { get; }
        public int Skip { get; }
        public SearchDirection SearchDirection { get; }
        public StringComparison StringComparison { get; }

        public void SetLeftAndHeadIndex(string source, int startIndex, IndexCollectionBuilder builder)
        {
            int left = 0;
            for (var i = 0; i <= Skip; i++)
            {
                switch (SearchDirection)
                {
                    case SearchDirection.Forward:
                        left = source.IndexOf(Value, startIndex, StringComparison);

                        if (left == -1)
                            throw new InvalidOperationException();

                        startIndex = left + 1;
                        break;
                    case SearchDirection.Backward:
                        left = source.LastIndexOf(Value, startIndex, StringComparison);

                        if (left == -1)
                            throw new InvalidOperationException();

                        startIndex = left - 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(SearchDirection));
                }
            }

            builder.Left = left;
            builder.Head = builder.Left + Value.Length;
        }

        public void SetRightIndex(string source, int startIndex, IndexCollectionBuilder builder)
        {
            int right = 0;
            for (var i = 0; i <= Skip; i++)
            {
                switch (SearchDirection)
                {
                    case SearchDirection.Forward:
                        right = source.IndexOf(Value, startIndex, StringComparison);

                        if (right == -1)
                            throw new InvalidOperationException();

                        startIndex = right + 1;
                        break;
                    case SearchDirection.Backward:
                        right = source.LastIndexOf(Value, startIndex, StringComparison);

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
