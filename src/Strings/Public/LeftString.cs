using System;
using StringExtractors.Indexes;
using StringExtractors.Strings;

namespace StringExtractors
{
    /// <summary>
    /// String locates at left side of extract target.
    /// </summary>
    public class LeftString
    {
        /// <summary>
        /// For basic usage.
        /// </summary>
        /// <param name="value">Value of <c>LeftString</c>.</param>
        /// <param name="skip">
        /// <inheritdoc cref="StringType.Skip" path="/summary"/>
        /// </param>
        /// <param name="direction">
        /// <inheritdoc cref="NormalStringType.SearchDirection" path="/summary"/>
        /// </param>
        /// <param name="stringComparison">
        /// <inheritdoc cref="NormalStringType.StringComparison" path="/summary"/>
        /// </param>
        public LeftString(
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
        /// <param name="value">Value and configurations of <c>LeftString</c>.</param>
        public LeftString(StringType value)
        {
            Value = value;
        }

        private StringType _value;
        /// <summary>
        /// <inheritdoc cref="LeftString(StringType)" path="/param[@name='value']"/>
        /// </summary>
        /// <value></value>
        public StringType Value
        {
            get => _value;
            set => _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal InternalLeftString CreateInternalModel(SearchOrder searchOrder)
        {
            SearchDirection autoSetDirection;

            switch (searchOrder)
            {
                case SearchOrder.LeftFirst:
                    autoSetDirection = SearchDirection.Forward;
                    break;
                case SearchOrder.RightFirst:
                    autoSetDirection = SearchDirection.Backward;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new InternalLeftString(Value.CreateInternalModel(autoSetDirection));
        }
    }
}
