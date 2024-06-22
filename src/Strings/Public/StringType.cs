using System;
using StringExtractors.Strings.InternalStringTypes;

namespace StringExtractors
{
    /// <summary>
    /// Value and configurations of <c>LeftString</c> or <c>RightString</c>
    /// </summary>
    public abstract class StringType
    {
        /// <summary>
        /// Use this when same string with <c>Value</c> (In case of a <c>NormalStringType</c>) or
        /// <c>Pattern</c> (In case of a <c>RegexStringType</c>) appears multiple times.
        /// It ignores same string with <c>Value</c> or matched string with <c>Pattern</c> 
        /// for specified times.
        /// </summary>
        /// <value>The number indicates how many times ignore same/matced string.</value>
        public int Skip { get; set; }

        // If SearchDirection property is null, this argument is applied.
        internal abstract IInternalStringType CreateInternalModel(SearchDirection autoSetDirection);
    }
}
