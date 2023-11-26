using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class InternalRightString : IIndexSetter, IRightStartIndex
    {
        public InternalRightString(IInternalStringType value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IInternalStringType Value { get; }
        public int StartIndex { get; set; }
        public SearchDirection SearchDirection { get => Value.SearchDirection; }

        public void SetIndex(string source, IndexCollectionBuilder builder)
        {
            Value.SetRightIndex(source, StartIndex, builder);
        }
    }
}
