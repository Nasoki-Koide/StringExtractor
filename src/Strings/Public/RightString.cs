using System;
using StringExtractors.Indexes;
using StringExtractors.Strings;

namespace StringExtractors
{
    public class RightString
    {
        public RightString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
            }

            Value = value;
        }

        public string Value { get; set; }
        // Q.It seems strange that SearchDirection is always Forward regardless of SearchOrder.
        // A.I think this is a natural behaviour. If SearchOrder is LeftFirst, you normally search
        //   RightString forward from the index where LeftString locates.
        //   If SearchOrder is RightFirst, you normally search RightString from the head of source.
        public SearchDirection SearchDirection { get; set; } = SearchDirection.Forward;
        public int Skip { get; set; }

        internal InternalRightString CreateInternalModel()
        {
            return new InternalRightString(Value, SearchDirection, Skip);
        }

    }
}
