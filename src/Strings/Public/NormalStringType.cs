using System;
using StringExtractors.Strings.InternalStringTypes;
using StringExtractors.Strings.InternalStringTypes.Normal;

namespace StringExtractors
{
    /// <summary>
    /// Use this when you want to use literal string.
    /// </summary>
    public class NormalStringType : StringType
    {
        /// <summary>
        /// Set literal string.
        /// </summary>
        /// <param name="value">
        /// <inheritdoc cref="Value" path="/summary"/>
        /// </param>
        public NormalStringType(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Value of <c>LeftString</c> or <c>RightString</c>.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Direction of searching value in source.
        /// </summary>
        /// <value><c>Forward</c> or <c>Backward</c>. Set <see langword="null"/>  if you want default behavior.</value>
        public SearchDirection? SearchDirection { get; set; }

        /// <summary>
        /// Culture, case, and sort rules for string comparison.
        /// </summary>
        /// <value>Default value is <c>CurrentCulture</c> </value>
        public StringComparison StringComparison { get; set; } = StringComparison.CurrentCulture;

        internal override IInternalStringType CreateInternalModel(SearchDirection autoSetDirection)
        {
            SearchDirection si = SearchDirection ?? autoSetDirection;

            return new NormalInternalStringType(Value, Skip, si, StringComparison);
        }
    }
}
