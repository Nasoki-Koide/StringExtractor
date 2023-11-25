using System;

namespace StringExtractors
{
    public class StringExtractorParameters
    {
        public StringExtractorParameters(
            string source,
            LeftString leftString = null,
            RightString rightString = null,
            SearchOrder searchOrder = SearchOrder.LeftFirst,
            int? startIndex = null)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
            LeftString = leftString;
            RightString = rightString;
            SearchOrder = searchOrder;
            StartIndex = startIndex;
        }

        public string Source { get; }
        public LeftString LeftString { get; }
        public RightString RightString { get; }
        public SearchOrder SearchOrder { get; }
        public int? StartIndex { get; }
    }
}
