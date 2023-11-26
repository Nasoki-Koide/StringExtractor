using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class InternalLeftString : IInternalLeftString
    {
        public InternalLeftString(string value, SearchDirection searchDirection, int skip, SearchOrder searchOrder)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
            }

            Value = value;
            SearchDirection = searchDirection;
            Skip = skip;
            SearchOrder = searchOrder;
        }

        public string Value { get; }
        public SearchDirection SearchDirection { get; }
        public int Skip { get; }
        public SearchOrder SearchOrder { get; }

        public void CalculateLeftAndHeadIndex(
            int startIndex,
            string source,
            IndexCollectionBuilder builder)
        {
            int left = 0;
            for (var i = 0; i <= Skip; i++)
            {
                switch (SearchDirection)
                {
                    case SearchDirection.Forward:
                        left = source.IndexOf(Value, startIndex);

                        if (left == -1)
                            throw new InvalidOperationException();

                        startIndex = left + 1;
                        break;
                    case SearchDirection.Backward:
                        left = source.LastIndexOf(Value, startIndex);

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
    }
}
