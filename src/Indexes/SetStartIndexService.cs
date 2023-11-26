using System;
using StringExtractors.Strings;

namespace StringExtractors.Indexes
{
    internal class SetStartIndexService
    {
        public SetStartIndexService(
            int? startIndex,
            string source,
            InternalLeftString leftString,
            InternalRightString rightString,
            SearchOrder order)
        {
            this.startIndex = startIndex;
            this.source = source;
            this.leftString = leftString;
            this.rightString = rightString;
            this.order = order;
        }

        private int? startIndex { get; }
        private string source { get; }
        private InternalLeftString leftString { get; }
        private InternalRightString rightString { get; }
        private SearchOrder order { get; }

        public void SetStartIndexForFirstString()
        {
            IStartIndex target;
            switch (order)
            {
                case SearchOrder.LeftFirst:
                    target = leftString.Value;
                    break;
                case SearchOrder.RightFirst:
                    target = rightString.Value;
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (startIndex.HasValue)
                target.StartIndex = startIndex.Value;
            else
                target.StartIndex = getEdgeIndex(target.SearchDirection);
        }

        public void SetStartIndexForSecondString(IndexCollectionBuilder builder)
        {
            IStartIndex target;
            switch (order)
            {
                case SearchOrder.LeftFirst:
                    target = rightString.Value;
                    break;
                case SearchOrder.RightFirst:
                    target = leftString.Value;
                    break;
                default:
                    throw new NotImplementedException();
            }

            switch (order)
            {
                // SecondString is RightString.
                case SearchOrder.LeftFirst:
                    switch (target.SearchDirection)
                    {
                        case SearchDirection.Forward:
                            target.StartIndex = builder.Head ?? getEdgeIndex(SearchDirection.Forward);
                            break;
                        case SearchDirection.Backward:
                            target.StartIndex = getEdgeIndex(SearchDirection.Backward);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;

                // SecondString is LeftString.
                case SearchOrder.RightFirst:
                    switch (target.SearchDirection)
                    {
                        case SearchDirection.Forward:
                            target.StartIndex = getEdgeIndex(SearchDirection.Forward);
                            break;
                        case SearchDirection.Backward:
                            target.StartIndex = builder.Right.HasValue ?
                                builder.Right.Value - 1 : getEdgeIndex(SearchDirection.Backward);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;

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
