using System;
using StringExtractors.Indexes;

namespace StringExtractors
{
    public readonly struct ExtractionResult
    {
        internal ExtractionResult(string value, IndexCollection indexCollection)
        {
            Value = value;
            IndexCollection = indexCollection ?? throw new ArgumentNullException(nameof(indexCollection));
        }

        public string Value { get; }
        public IndexCollection IndexCollection { get; }
    }
}
