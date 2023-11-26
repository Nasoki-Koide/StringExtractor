using System;
using StringExtractors.Indexes;
using StringExtractors.Strings;

namespace StringExtractors
{
    public class RightString
    {
        public RightString(string value)
        {
            Value = new NormalStringType(value);
        }

        public RightString(StringType value)
        {
            Value = value;
        }

        private StringType _value;
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
