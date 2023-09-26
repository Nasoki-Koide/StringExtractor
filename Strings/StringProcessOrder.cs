using System;

namespace StringExtractors.Strings
{
    // TODO:Should reconsider class name.
    internal class StringProcessOrder
    {
        public StringProcessOrder(KeyString firstString, KeyString secondString)
        {
            FirstString = firstString ?? throw new ArgumentNullException(nameof(firstString));
            SecondString = secondString ?? throw new ArgumentNullException(nameof(secondString));
        }

        public KeyString FirstString { get; }
        public KeyString SecondString { get; }
    }
}
