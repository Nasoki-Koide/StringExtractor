using System;
using StringExtractors.Indexes;
using StringExtractors.Strings;

namespace StringExtractors
{
    public static class StringExtractor
    {
        public static ExtractionResult Extract(
            string source,
            string leftString = null,
            string rightString = null)
        {
            LeftString ls = string.IsNullOrEmpty(leftString) ? null : new LeftString(leftString);

            RightString rs = string.IsNullOrEmpty(rightString) ? null : new RightString(rightString);

            return Extract(new StringExtractorParameters(source, ls, rs));
        }

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
                    ((IIndexSetter)internalLeftStr).SetIndex(
                        parameters.Source,
                        indexCollectionBuilder);
                    setStartIndexService.SetStartIndexForSecondString(indexCollectionBuilder);
                    ((IIndexSetter)internalRightStr).SetIndex(
                        parameters.Source,
                        indexCollectionBuilder);
                    break;

                case SearchOrder.RightFirst:
                    setStartIndexService.SetStartIndexForFirstString();
                    ((IIndexSetter)internalRightStr).SetIndex(
                        parameters.Source,
                        indexCollectionBuilder);
                    setStartIndexService.SetStartIndexForSecondString(indexCollectionBuilder);
                    ((IIndexSetter)internalLeftStr).SetIndex(
                        parameters.Source,
                        indexCollectionBuilder);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(parameters.SearchOrder));
            }

            var indexCollection = indexCollectionBuilder.Build();

            string extractedString = indexCollection.ExtractFrom(parameters.Source);

            return new ExtractionResult(extractedString, indexCollection);
        }
    }
}
