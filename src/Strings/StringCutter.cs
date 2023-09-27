using System;

namespace StringExtractors.Strings
{
    internal class StringCutter
    {
        public StringCutter(
            string source,
            SearchOrder searchOrder,
            ILeftString leftString,
            IRightString rightString)
        {
            this.source = source ?? throw new ArgumentNullException(nameof(source));
            this.searchOrder = searchOrder;
            this.leftString = leftString ?? throw new ArgumentNullException(nameof(leftString));
            this.rightString = rightString ?? throw new ArgumentNullException(nameof(rightString));
        }

        private string source { get; set; }
        private SearchOrder searchOrder { get; }
        private ILeftString leftString { get; }
        private IRightString rightString { get; }

        private string firstCut()
        {
            switch (searchOrder)
            {
                case SearchOrder.LeftFirst:
                    return leftString.Cut(source);
                case SearchOrder.RightFirst:
                    return rightString.Cut(source);
                default:
                    throw new NotImplementedException();
            }
        }

        private string secondCut(string sourceAfterFirstCut)
        {
            switch (searchOrder)
            {
                case SearchOrder.LeftFirst:
                    return rightString.Cut(sourceAfterFirstCut);
                case SearchOrder.RightFirst:
                    return leftString.Cut(sourceAfterFirstCut);
                default:
                    throw new NotImplementedException();
            }
        }

        public string Cut()
        {
            var str = firstCut();
            return secondCut(str);
        }
    }
}
