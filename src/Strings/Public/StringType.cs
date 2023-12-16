using System;
using StringExtractors.Strings.InternalStringTypes;

namespace StringExtractors
{
    public abstract class StringType
    {
        public int Skip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="autoSetDirection">If SearchDirection property is null, this argument is applied.</param>
        /// <returns></returns>
        internal abstract IInternalStringType CreateInternalModel(SearchDirection autoSetDirection);
    }
}
