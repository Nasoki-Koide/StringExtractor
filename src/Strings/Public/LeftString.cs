using System;
using StringExtractors.Indexes;
using StringExtractors.Strings;

namespace StringExtractors
{
    public class LeftString
    {
        public LeftString(string value, int skip = 0, SearchDirection? direction = null, StringComparison stringComparison = StringComparison.CurrentCulture)
        {
            Value = new NormalStringType(value)
            {
                Skip = skip,
                SearchDirection = direction,
                StringComparison = stringComparison
            };
        }

        public LeftString(StringType value)
        {
            Value = value;
        }

        private StringType _value;
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

            return new InternalLeftString(Value.CreateInternalModel(
                autoSetDirection: autoSetDirection));
        }
    }
}
