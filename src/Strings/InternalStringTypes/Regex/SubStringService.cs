using System;

namespace StringExtractors.Strings.InternalStringTypes.Regex
{
    internal class SubStringService
    {
        public SubStringService(SearchDirection searchDirection)
        {
            this.searchDirection = searchDirection;
        }

        private SearchDirection searchDirection { get; }

        public string GetSubString(string source, int startIndex)
        {
            switch (searchDirection)
            {
                case SearchDirection.Forward:
                    return source.Substring(startIndex);
                case SearchDirection.Backward:
                    return source.Substring(0, startIndex + 1);
                default:
                    throw new InvalidOperationException(nameof(searchDirection));
            }
        }
    }
}
