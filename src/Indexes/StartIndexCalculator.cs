using System;

namespace StringExtractors.Indexes
{
    internal class StartIndexCalculator
    {
        public StartIndexCalculator(int? startIndex, string source)
        {
            this.startIndex = startIndex;
            this.source = source ?? throw new ArgumentNullException(nameof(source));
        }

        private int? startIndex { get; }
        private int startIndexForSecond { get; set; }
        public string source { get; }

        public int CalculateFirstString(SearchDirection direction)
        {
            if (startIndex.HasValue)
                return startIndex.Value;

            var index = getEdgeIndex(direction);

            startIndexForSecond = index;

            return index;
        }

        public int CalculateSecondString(SearchDirection direction, SearchOrder order)
        {
            switch (order)
            {
                // SecondString is RightString.
                case SearchOrder.LeftFirst:
                    switch (direction)
                    {
                        case SearchDirection.Forward:
                            return startIndexForSecond;
                        case SearchDirection.Backward:
                            return getEdgeIndex(direction);
                        default:
                            throw new NotImplementedException();
                    }

                // SecondString is LeftString.
                case SearchOrder.RightFirst:
                    switch (direction)
                    {
                        case SearchDirection.Forward:
                            return getEdgeIndex(direction);
                        case SearchDirection.Backward:
                            return startIndexForSecond;
                        default:
                            throw new NotImplementedException();
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        private int getEdgeIndex(SearchDirection direction)
        {
            switch (direction)
            {
                case SearchDirection.Forward:
                    return 0;
                case SearchDirection.Backward:
                    return source.Length - 1;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
