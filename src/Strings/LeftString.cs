using System;
using StringExtractors.Indexes;

namespace StringExtractors
{
    public class LeftString
    {
        public LeftString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
            }

            Value = value;
        }

        public string Value { get; set; }
        public SearchDirection? SearchDirection { get; set; } = null;
        public int Skip { get; set; }
        internal SearchOrder SearchOrder { get; private set; }
        internal void SetSearchOrderAndDirection(SearchOrder value)
        {
            SearchOrder = value;

            if (SearchDirection is null)
                switch (SearchOrder)
                {
                    case SearchOrder.LeftFirst:
                        SearchDirection = StringExtractors.SearchDirection.Forward;
                        break;
                    case SearchOrder.RightFirst:
                        SearchDirection = StringExtractors.SearchDirection.Backward;
                        break;
                    default:
                        throw new NotImplementedException();
                }
        }

        internal void CalculateLeftAndHeadIndex(
            int startIndex,
            string source,
            IndexCollectionBuilder builder)
        {
            int left = 0;
            for (var i = 0; i <= Skip; i++)
            {
                switch (SearchDirection)
                {
                    case StringExtractors.SearchDirection.Forward:
                        left = source.IndexOf(Value, startIndex);

                        if (left == -1)
                            throw new InvalidOperationException();

                        startIndex = left + 1;
                        break;
                    case StringExtractors.SearchDirection.Backward:
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
