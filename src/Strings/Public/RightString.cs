using System;
using StringExtractors.Indexes;
using StringExtractors.Strings;

namespace StringExtractors
{
    /// <summary>
    /// String locates at right side of extract target.
    /// </summary>
    public class RightString
    {
        /// <summary>
        /// For basic usage.
        /// </summary>
        /// <param name="value">Value of <c>RightString</c>.</param>
        /// <param name="skip">
        /// <inheritdoc cref="StringType.Skip" path="/summary"/>
        /// </param>
        /// <param name="direction">
        /// <inheritdoc cref="NormalStringType.SearchDirection" path="/summary"/>
        /// </param>
        /// <param name="stringComparison">
        /// <inheritdoc cref="NormalStringType.StringComparison" path="/summary"/>
        /// </param>
        public RightString(
            string value,
            int skip = 0,
            SearchDirection? direction = null,
            StringComparison stringComparison = StringComparison.CurrentCulture)
        {
            Value = new NormalStringType(value)
            {
                Skip = skip,
                SearchDirection = direction,
                StringComparison = stringComparison
            };
        }

        /// <summary>
        /// For advanced usage.
        /// </summary>
        /// <param name="value">Value and configurations of <c>RightString</c>.</param>
        public RightString(StringType value)
        {
            Value = value;
        }

        private StringType _value;
        /// <summary>
        /// <inheritdoc cref="RightString(StringType)" path="/param[@name='value']"/>
        /// </summary>
        /// <value></value>
        public StringType Value
        {
            get => _value;
            set => _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal InternalRightString CreateInternalModel()
        {
            // Q.It seems strange that SearchDirection is always Forward regardless of SearchOrder.
            // A.I think this is a natural behavior. If SearchOrder is LeftFirst, you normally search
            //   RightString forward from the index where LeftString locates.
            //   If SearchOrder is RightFirst, you normally search RightString from the head of source.
            return new InternalRightString(Value.CreateInternalModel(SearchDirection.Forward));
        }

    }
}
