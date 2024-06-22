using System;

namespace StringExtractors
{
    /// <summary>
    /// Same with <see href="https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regexoptions?view=net-8.0"><c>RegexOptions</c></see>, except <c>LeftToRight</c> is added here.
    /// </summary>
    [Flags]
    public enum RegexStringTypeOptions
    {
#pragma warning disable CS1591
        None = 0,
        IgnoreCase = 1,
        Multiline = 2,
        ExplicitCapture = 4,
        Compiled = 8,
        Singleline = 16,
        IgnorePatternWhitespace = 32,
        RightToLeft = 64,
        ECMAScript = 256,
        CultureInvariant = 512,
        LeftToRight = 1024
#pragma warning restore CS1591
    }
}
