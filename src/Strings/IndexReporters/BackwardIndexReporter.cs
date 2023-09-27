using System;

namespace StringExtractors.Strings.IndexReporters
{
    internal class BackwardIndexReporter : IIndexReporter
    {
        public int ReportIndex(string source, string value)
        {
            var index = source.LastIndexOf(value);

            if (index == -1)
                throw new ArgumentException($"{nameof(source)} does not include {nameof(value)}");

            return index;
        }
    }
}
