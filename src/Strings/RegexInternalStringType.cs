using System;
using System.Text.RegularExpressions;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class RegexInternalStringType : IInternalStringType
    {
        public RegexInternalStringType(string pattern, int skip, RegexStringTypeOptions options)
        {
            this.pattern = pattern;
            this.Skip = skip;
            this.options = options;
        }

        private string pattern { get; }
        private RegexStringTypeOptions options { get; }
        public int Skip { get; }
        public int StartIndex { get; set; }

        public SearchDirection SearchDirection
        {
            get
            {
                if (options.HasFlag(RegexStringTypeOptions.RightToLeft))
                    return SearchDirection.Backward;
                else if (options.HasFlag(RegexStringTypeOptions.LeftToRight))
                    return SearchDirection.Forward;
                else
                    throw new NotImplementedException();
            }
        }

        public void SetLeftAndHeadIndex(string source, IndexCollectionBuilder builder)
        {
            int left = 0;
            Match match = null;
            for (var i = 0; i <= Skip; i++)
            {
                // Regardless of SearchDirection, the following code is applied.
                // Because, if SearchDirection is Backward, options contains RightToLeft. 
                match = Regex.Match(source.Substring(StartIndex), pattern, convertOptions());

                if (match.Index == -1)
                    throw new InvalidOperationException();
                left = match.Index + StartIndex;
                switch (SearchDirection)
                {
                    case SearchDirection.Forward:
                        StartIndex = left + 1;
                        break;
                    case SearchDirection.Backward:
                        StartIndex = left - 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(SearchDirection));
                }
            }

            builder.Left = left;
            builder.Head = builder.Left + match.Length;
        }

        public void SetRightIndex(string source, IndexCollectionBuilder builder)
        {
            int right = 0;
            for (var i = 0; i <= Skip; i++)
            {
                // Regardless of SearchDirection, the following code is correct.
                // Because, if SearchDirection is Backward, options contains RightToLeft. 
                var match = Regex.Match(source.Substring(StartIndex), pattern, convertOptions());

                if (match.Index == -1)
                    throw new InvalidOperationException();
                right = match.Index + StartIndex;
                switch (SearchDirection)
                {
                    case SearchDirection.Forward:
                        StartIndex = right + 1;
                        break;
                    case SearchDirection.Backward:
                        StartIndex = right - 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(SearchDirection));
                }
            }

            builder.Right = right;
        }

        private RegexOptions convertOptions()
        {
            var withoutLeftToRight = options & ~RegexStringTypeOptions.LeftToRight;
            return (RegexOptions)withoutLeftToRight;
        }
    }
}
