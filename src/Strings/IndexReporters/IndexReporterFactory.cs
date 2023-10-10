using System;

namespace StringExtractors.Strings.IndexReporters
{
    internal static class IndexReporterFactory
    {
        public static IIndexReporter Create(SearchDirection searchDirection)
        {
            switch (searchDirection)
            {
                case SearchDirection.Forward:
                    return new ForwardIndexReporter();
                case SearchDirection.Backward:
                    return new BackwardIndexReporter();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
