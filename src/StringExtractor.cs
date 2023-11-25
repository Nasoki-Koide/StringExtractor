using System;
using StringExtractors.Strings;

namespace StringExtractors
{
    public static class StringExtractor
    {
        public static ExtractionResult Extract(
            string source,
            string leftString = null,
            string rightString = null)
        {
            ILeftString ls = string.IsNullOrEmpty(leftString) ?
                (ILeftString)new NullLeftString() : new LeftString(leftString);

            IRightString rs = string.IsNullOrEmpty(rightString) ?
                (IRightString)new NullRightString() : new RightString(rightString);

            return Extract(source, ls, rs);
        }

        public static ExtractionResult Extract(
            string source,
            ILeftString leftString,
            IRightString rightString,
            SearchOrder searchOrder = SearchOrder.LeftFirst,
            int startLocation = 0)
        {
            var cutter = new StringCutter(source, searchOrder, leftString, rightString);
            return new ExtractionResult(cutter.Cut());
        }
    }
}
