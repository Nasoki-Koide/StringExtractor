using System;
using System.Text.RegularExpressions;
using StringExtractors.Strings;

namespace StringExtractors
{
    public class RegexStringType : StringType
    {
        public RegexStringType(string pattern)
        {
            Pattern = pattern;
        }

        public string Pattern { get; set; }
        private RegexStringTypeOptions _options;
        public RegexStringTypeOptions Options
        {
            get => _options; set
            {
                if (value.HasFlag(RegexStringTypeOptions.LeftToRight) &&
                    value.HasFlag(RegexStringTypeOptions.RightToLeft))
                    throw new ArgumentException("Cannot set LeftToRight and RightToLeft in same instance.", nameof(value));
                _options = value;
            }
        }

        internal override IInternalStringType CreateInternalModel(SearchDirection autoSetDirection)
        {
            var o = Options;

            if (!o.HasFlag(RegexStringTypeOptions.RightToLeft) &&
                !o.HasFlag(RegexStringTypeOptions.LeftToRight))
                switch (autoSetDirection)
                {
                    case SearchDirection.Forward:
                        o |= RegexStringTypeOptions.LeftToRight;
                        break;
                    case SearchDirection.Backward:
                        o |= RegexStringTypeOptions.RightToLeft;
                        break;
                    default:
                        throw new NotImplementedException();
                }

            return new RegexInternalStringType(Pattern, Skip, o);
        }
    }
}
