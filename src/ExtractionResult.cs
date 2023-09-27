using System;

namespace StringExtractors
{
    public readonly struct ExtractionResult
    {
        internal ExtractionResult(string value)
        {
            Value = value;
        }

        public string Value { get; }

        // In future, maybe I will add some property like a index of Value in source.
    }
}
