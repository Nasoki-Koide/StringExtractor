using System;
using StringExtractors.Strings.InternalStringTypes;
using StringExtractors.Strings.InternalStringTypes.Normal;

namespace StringExtractors
{
    public class NormalStringType : StringType
    {
        public NormalStringType(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
        public SearchDirection? SearchDirection { get; set; }
        public StringComparison StringComparison { get; set; }

        internal override IInternalStringType CreateInternalModel(SearchDirection autoSetDirection)
        {
            SearchDirection si = SearchDirection ?? autoSetDirection;

            return new NormalInternalStringType(Value, Skip, si, StringComparison);
        }
    }
}
