using System;
using StringExtractors.Indexes;
using StringExtractors.Strings;
using StringExtractors.Strings.InternalStringTypes.Null;

namespace StringExtractors
{
    /// <summary>
    /// Please use this to extract string.
    /// </summary>
    public static class StringExtractor
    {
        /// <summary>
        /// Extracts string between left/rightString.
        /// </summary>
        /// <param name="source">String which contains extract target.</param>
        /// <param name="leftString">
        /// <inheritdoc cref="LeftString" path="/summary"/> Omit this if extract target
        /// locates at head of source.
        /// </param>
        /// <param name="rightString">
        /// <inheritdoc cref="RightString" path="/summary"/> Omit this if extract target
        /// locates at end of source.
        /// </param>
        /// <returns>ExtractionResult, which contains extracted string and indexes.</returns> 
        public static ExtractionResult Extract(
            string source,
            string leftString = null,
            string rightString = null)
        {
            LeftString ls = string.IsNullOrEmpty(leftString) ? null : new LeftString(leftString);

            RightString rs = string.IsNullOrEmpty(rightString) ? null : new RightString(rightString);

            return Extract(new StringExtractorParameters(source, ls, rs));
        }

        /// <summary>
        /// Extracts string between left/rightString.
        /// </summary>
        /// <param name="parameters">Parameters for extracting string.</param>
        /// <returns></returns>
        public static ExtractionResult Extract(StringExtractorParameters parameters)
        {
            if (parameters.Source is null)
                return new ExtractionResult(null, new IndexCollection(null, null, null));

            var indexCollectionBuilder = new IndexCollectionBuilder();
            var internalLeftStr = parameters.LeftString?.CreateInternalModel(parameters.SearchOrder) ??
                new InternalLeftString(new NullInternalStringType());
            var internalRightStr = parameters.RightString?.CreateInternalModel() ??
                new InternalRightString(new NullInternalStringType());
            var setStartIndexService = new SetStartIndexService(
                parameters.StartIndex, parameters.Source, internalLeftStr, internalRightStr, parameters.SearchOrder);

            switch (parameters.SearchOrder)
            {
                case SearchOrder.LeftFirst:
                    setStartIndexService.SetStartIndexForFirstString();
                    internalLeftStr.SetIndex(
                        parameters.Source,
                        indexCollectionBuilder);
                    setStartIndexService.SetStartIndexForSecondString(indexCollectionBuilder);
                    ((IIndexSetter)internalRightStr).SetIndex(
                        parameters.Source,
                        indexCollectionBuilder);
                    break;

                case SearchOrder.RightFirst:
                    setStartIndexService.SetStartIndexForFirstString();
                    internalRightStr.SetIndex(
                        parameters.Source,
                        indexCollectionBuilder);
                    setStartIndexService.SetStartIndexForSecondString(indexCollectionBuilder);
                    internalLeftStr.SetIndex(
                        parameters.Source,
                        indexCollectionBuilder);
                    break;

                default:
                    throw new InvalidOperationException(nameof(parameters.SearchOrder));
            }

            var indexCollection = indexCollectionBuilder.Build();

            string extractedString = indexCollection.ExtractFrom(parameters.Source);

            return new ExtractionResult(extractedString, indexCollection);
        }
    }
}
