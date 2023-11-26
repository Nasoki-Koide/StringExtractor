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
            Source = source;
            LeftString = leftString;
            RightString = rightString;
            SearchOrder = searchOrder;
            StartIndex = startIndex;
        }

        public string Source { get; set; }
        public LeftString LeftString { get; set; }
        public RightString RightString { get; set; }
        public SearchOrder SearchOrder { get; set; }
        public int? StartIndex { get; set; }
    }
}
