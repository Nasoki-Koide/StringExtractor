using System;

namespace StringExtractors.Strings.IndexReporters
{
    internal interface IIndexReporter
    {
        int ReportIndex(string source, string value);
    }
}
