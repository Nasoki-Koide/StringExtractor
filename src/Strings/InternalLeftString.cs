using System;
using StringExtractors.Indexes;

namespace StringExtractors.Strings
{
    internal class InternalLeftString : IIndexSetter, ILeftStartIndex
    {
        public InternalLeftString(IInternalStringType value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IInternalStringType Value { get; }
        public int StartIndex { get; set; }
        public SearchDirection SearchDirection { get => Value.SearchDirection; }

        public void SetIndex(string source, IndexCollectionBuilder builder)
        {
            Value.SetLeftAndHeadIndex(source, StartIndex, builder);
        }
    }
}
