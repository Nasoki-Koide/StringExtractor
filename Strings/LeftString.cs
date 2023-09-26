using System;
using StringExtractors.Strings.IndexReporters;

namespace StringExtractors
{
    public class LeftString : ILeftString
    {
        public LeftString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"'{nameof(value)}' cannot be null or empty.", nameof(value));
            }

            Value = value;
        }

        public string Value { get; set; }
        public SearchDirection SearchDirection { get; set; } = SearchDirection.Forward;

        public string Cut(string source)
        {
            var indexReporter = IndexReporterFactory.Create(SearchDirection);

            var offsetIndex = indexReporter.ReportIndex(source, Value) + Value.Length;

            return source.Substring(offsetIndex);
        }

    }
}
