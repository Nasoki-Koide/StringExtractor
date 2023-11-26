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
            var startIndexCalculator = new StartIndexCalculator(parameters.StartIndex, parameters.Source);

            var internalLeftStr = parameters.LeftString?.CreateInternalModel(parameters.SearchOrder) ??
                (IInternalLeftString)new NullInternalLeftString();
            var internalRightString = parameters.RightString?.CreateInternalModel() ??
                (IInternalRightString)new NullInternalRightString();

            switch (parameters.SearchOrder)
            {
                case SearchOrder.LeftFirst:
                    internalLeftStr.CalculateLeftAndHeadIndex(
                        startIndexCalculator.CalculateFirstString(parameters.LeftString.SearchDirection.Value),
                        parameters.Source,
                        indexCollectionBuilder);
                    internalRightString.CalculateRightIndex(
                        startIndexCalculator.CalculateSecondString(parameters.RightString.SearchDirection, parameters.SearchOrder),
                        parameters.Source,
                        indexCollectionBuilder);
                    break;

                case SearchOrder.RightFirst:
                    internalRightString.CalculateRightIndex(
                        startIndexCalculator.CalculateFirstString(parameters.RightString.SearchDirection),
                        parameters.Source,
                        indexCollectionBuilder);
                    internalLeftStr.CalculateLeftAndHeadIndex(
                        startIndexCalculator.CalculateSecondString(parameters.LeftString.SearchDirection.Value, parameters.SearchOrder),
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
