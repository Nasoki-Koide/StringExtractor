using System;
using StringExtractors.Indexes;

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
            var indexCollectionBuilder = new IndexCollectionBuilder();
            var startIndexCalculator = new StartIndexCalculator(parameters.StartIndex, parameters.Source);

            switch (parameters.SearchOrder)
            {
                case SearchOrder.LeftFirst:
                    parameters.LeftString.SetSearchOrderAndDirection(parameters.SearchOrder);
                    parameters.LeftString.CalculateLeftAndHeadIndex(
                        startIndexCalculator.CalculateFirstString(parameters.LeftString.SearchDirection.Value),
                        parameters.Source,
                        indexCollectionBuilder);
                    parameters.RightString.CalculateRightIndex(
                        startIndexCalculator.CalculateSecondString(parameters.RightString.SearchDirection, parameters.SearchOrder),
                        parameters.Source,
                        indexCollectionBuilder);
                    break;

                case SearchOrder.RightFirst:
                    parameters.LeftString.SetSearchOrderAndDirection(parameters.SearchOrder);
                    parameters.RightString.CalculateRightIndex(
                        startIndexCalculator.CalculateFirstString(parameters.RightString.SearchDirection),
                        parameters.Source,
                        indexCollectionBuilder);
                    parameters.LeftString.CalculateLeftAndHeadIndex(
                        startIndexCalculator.CalculateSecondString(parameters.LeftString.SearchDirection.Value, parameters.SearchOrder),
                        parameters.Source,
                        indexCollectionBuilder);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(parameters.SearchOrder));
            }

            var indexCollection = indexCollectionBuilder.Build();

            var extractedString = parameters.Source.Substring(
                indexCollection.Head, indexCollection.Right - indexCollection.Head);

            return new ExtractionResult(extractedString, indexCollection);
        }
    }
}
