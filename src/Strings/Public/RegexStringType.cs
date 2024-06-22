using System;
using System.Text.RegularExpressions;
using StringExtractors.Strings.InternalStringTypes;
using StringExtractors.Strings.InternalStringTypes.Regex;

namespace StringExtractors
{
    /// <summary>
    /// Use this when you want to use regular expression.
    /// </summary>
    public class RegexStringType : StringType
    {
        /// <summary>
        /// Set pattern of regular expression.
        /// </summary>
        /// <param name="pattern"></param>
        public RegexStringType(string pattern)
        {
            Pattern = pattern;
        }

        /// <summary>
        /// Regular expression pattern of <c>LeftString</c> or <c>RightString</c>.
        /// </summary>
        public string Pattern { get; set; }
        private RegexStringTypeOptions _options;
        /// <summary>
        /// Options of regular expression.
        /// </summary>
        public RegexStringTypeOptions Options
        {
            get => _options; set
            {
                if (value.HasFlag(RegexStringTypeOptions.LeftToRight) &&
                    value.HasFlag(RegexStringTypeOptions.RightToLeft))
                    throw new ArgumentException($"Cannot set {nameof(RegexStringTypeOptions.LeftToRight)} and {nameof(RegexStringTypeOptions.RightToLeft)} in same instance.", nameof(value));
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
                        throw new InvalidOperationException(nameof(autoSetDirection));
                }

            return new RegexInternalStringType(Pattern, Skip, o);
        }
    }
}
