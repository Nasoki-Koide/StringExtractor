using System;
using System.Text.RegularExpressions;
using StringExtractors.Indexes;

namespace StringExtractors.Strings.InternalStringTypes.Regex
{
    internal class RegexInternalStringType : IInternalStringType
    {
        public RegexInternalStringType(string pattern, int skip, RegexStringTypeOptions options)
        {
            this.pattern = pattern;
            Skip = skip;
            this.options = options;

            _subStringService = new SubStringService(SearchDirection);
            _adjustIndexService = new AdjustIndexService(SearchDirection);
        }

        private string pattern { get; }
        private RegexStringTypeOptions options { get; }
        public int Skip { get; }
        public int StartIndex { get; set; }
        private readonly SubStringService _subStringService;
        private readonly AdjustIndexService _adjustIndexService;

        public SearchDirection SearchDirection
        {
            get
            {
                if (options.HasFlag(RegexStringTypeOptions.RightToLeft))
                    return SearchDirection.Backward;
                else if (options.HasFlag(RegexStringTypeOptions.LeftToRight))
                    return SearchDirection.Forward;
                else
                    throw new InvalidOperationException($"You must set {nameof(RegexStringTypeOptions.LeftToRight)} or {nameof(RegexStringTypeOptions.RightToLeft)} to {nameof(RegexStringTypeOptions)}.");
            }
        }

        public void SetLeftAndHeadIndex(string source, IndexCollectionBuilder builder)
        {
            int left = 0;
            Match match = null;
            for (var i = 0; i <= Skip; i++)
            {
                match = System.Text.RegularExpressions.Regex
                    .Match(_subStringService.GetSubString(source, StartIndex), pattern, convertOptions());

                if (match.Index == -1)
                    throw new InvalidOperationException(ErrorMessages.LeftStringWasNotFound);

                left = _adjustIndexService.Adjust(match, StartIndex);
                switch (SearchDirection)
                {
                    case SearchDirection.Forward:
                        StartIndex = left + 1;
                        break;
                    case SearchDirection.Backward:
                        StartIndex = left - 1;
                        break;
                    default:
                        throw new InvalidOperationException(nameof(SearchDirection));
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
                var match = System.Text.RegularExpressions.Regex
                    .Match(_subStringService.GetSubString(source, StartIndex), pattern, convertOptions());

                if (match.Index == -1)
                    throw new InvalidOperationException(ErrorMessages.RightStringWasNotFound);

                right = _adjustIndexService.Adjust(match, StartIndex);
                switch (SearchDirection)
                {
                    case SearchDirection.Forward:
                        StartIndex = right + 1;
                        break;
                    case SearchDirection.Backward:
                        StartIndex = right - 1;
                        break;
                    default:
                        throw new InvalidOperationException(nameof(SearchDirection));
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
