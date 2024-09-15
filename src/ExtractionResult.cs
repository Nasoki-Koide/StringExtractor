using System;
using StringExtractors.Indexes;

namespace StringExtractors
{
#pragma warning disable CS1591
    public readonly struct ExtractionResult
#pragma warning restore CS1591

    {
        internal ExtractionResult(string value, IndexCollection indexCollection)
        {
            Value = value;
            IndexCollection = indexCollection ?? throw new ArgumentNullException(nameof(indexCollection));
        }

        /// <summary>
        /// Value of extracted string.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// <inheritdoc cref="StringExtractors.IndexCollection" path="/summary"/>
        /// </summary>
        public IndexCollection IndexCollection { get; }
    }
}
