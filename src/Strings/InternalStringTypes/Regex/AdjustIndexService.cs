using System;
using System.Text.RegularExpressions;

namespace StringExtractors.Strings.InternalStringTypes.Regex
{
    internal class AdjustIndexService
    {
        public AdjustIndexService(SearchDirection searchDirection)
        {
            this.searchDirection = searchDirection;
        }

        private SearchDirection searchDirection { get; }

        public int Adjust(Match match, int startIndex)
        {
            switch (searchDirection)
            {
                case SearchDirection.Forward:
                    return match.Index + startIndex;
                case SearchDirection.Backward:
                    return match.Index;
                default:
                    throw new InvalidOperationException(nameof(searchDirection));
            }
        }
    }
}
