using System;
using System.Text.RegularExpressions;
using StringExtractors.Strings;
using StringExtractors.Strings.Public;

namespace StringExtractors
{
    public class RegexStringType : StringType
    {
        public RegexStringType(string pattern, RegexStringTypeOptions options)
        {
            Pattern = pattern;

            if (options.HasFlag(RegexStringTypeOptions.LeftToRight) &&
                options.HasFlag(RegexStringTypeOptions.RightToLeft))
                throw new ArgumentException("Cannot set LeftToRight and RightToLeft in same instance.", nameof(options));

            Options = options;
        }

        public string Pattern { get; set; }
        public RegexStringTypeOptions Options { get; set; }

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
