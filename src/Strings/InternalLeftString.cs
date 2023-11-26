using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class InternalLeftString : IIndexSetter
    {
        public InternalLeftString(IInternalStringType value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IInternalStringType Value { get; }
        public SearchDirection SearchDirection { get => Value.SearchDirection; }

        public void SetIndex(string source, IndexCollectionBuilder builder)
        {
            Value.SetLeftAndHeadIndex(source, builder);
        }
    }
}
