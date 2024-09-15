using System;

namespace StringExtractors.Strings.InternalStringTypes
{
    internal static class ErrorMessages
    {
        public static string LeftStringWasNotFound => $"{nameof(LeftString)} was not found in source.";
        public static string RightStringWasNotFound => $"{nameof(RightString)} was not found in source.";
    }
}
