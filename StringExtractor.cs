using System;
using StringExtractors.Strings;

namespace StringExtractors
{
    public static class StringExtractor
    {
        public static ExtractionResult Extract(
            string source, LeftString leftString, RightString rightString, SearchOrder searchOrder)
        {
            var cutter = new StringCutter(source, searchOrder, leftString, rightString);
            return new ExtractionResult(cutter.Cut());
        }
    }
}
