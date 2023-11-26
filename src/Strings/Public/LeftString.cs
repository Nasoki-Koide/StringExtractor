using System;
using StringExtractors.Indexes;
using StringExtractors.Strings;

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

        internal InternalLeftString CreateInternalModel(SearchOrder searchOrder)
        {
            var sd = SearchDirection;

            if (sd is null)
                switch (searchOrder)
                {
                    case SearchOrder.LeftFirst:
                        sd = StringExtractors.SearchDirection.Forward;
                        break;
                    case SearchOrder.RightFirst:
                        sd = StringExtractors.SearchDirection.Backward;
                        break;
                    default:
                        throw new NotImplementedException();
                }

            return new InternalLeftString(Value, sd.Value, Skip, searchOrder);
        }
    }
}
