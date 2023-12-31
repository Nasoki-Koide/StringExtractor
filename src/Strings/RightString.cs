using System;
using StringExtractors.Strings;
using StringExtractors.Strings.IndexReporters;

namespace StringExtractors
{
    public class RightString : IRightString
    {
        public RightString(string value)
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

            var index = indexReporter.ReportIndex(source, Value);

            return source.Remove(index);
        }
    }
}
