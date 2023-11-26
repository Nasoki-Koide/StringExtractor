using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class InternalRightString : IIndexSetter
    {
        public InternalRightString(IInternalStringType value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IInternalStringType Value { get; }
        public SearchDirection SearchDirection { get => Value.SearchDirection; }

        public void SetIndex(string source, IndexCollectionBuilder builder)
        {
            Value.SetRightIndex(source, builder);
        }
    }
}
