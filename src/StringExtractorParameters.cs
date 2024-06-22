using System;

namespace StringExtractors
{
    /// <summary>
    /// Please use this when you need complex settings.
    /// </summary>
    public class StringExtractorParameters
    {
        /// <summary>
        /// Set parameters.
        /// </summary>
        /// <param name="source">String which contains extract target.</param>
        /// <param name="leftString">
        /// String locates at left side of extract target. Omit this if extract target
        /// locates at head of source.
        /// </param> 
        /// <param name="rightString">
        /// String locates at right side of extract target. Omit this if extract target
        /// locates at end of source.
        /// </param>
        /// <param name="searchOrder">
        /// Specified string (<paramref name="leftString"/> or <paramref name="rightString"/>) is searched first.
        /// </param>
        /// <param name="startIndex">Index of start searching.</param>
        public StringExtractorParameters(
            string source,
            LeftString leftString = null,
            RightString rightString = null,
            SearchOrder searchOrder = SearchOrder.LeftFirst,
            int? startIndex = null)
        {
            Source = source;
            LeftString = leftString;
            RightString = rightString;
            SearchOrder = searchOrder;
            StartIndex = startIndex;
        }

        /// <summary>
        /// <inheritdoc cref='StringExtractorParameters(string, LeftString, RightString, SearchOrder, int?)' path='/param[@name="source"]'/>
        /// </summary>
        /// <value></value>
        public string Source { get; set; }
        /// <summary>
        /// <inheritdoc cref='StringExtractorParameters(string, LeftString, RightString, SearchOrder, int?)' path='/param[@name="leftString"]'/>
        /// </summary>
        /// <value></value>
        public LeftString LeftString { get; set; }
        /// <summary>
        /// <inheritdoc cref='StringExtractorParameters(string, LeftString, RightString, SearchOrder, int?)' path='/param[@name="rightString"]'/>
        /// </summary>
        /// <value></value>
        public RightString RightString { get; set; }
        /// <summary>
        /// <inheritdoc cref='StringExtractorParameters(string, LeftString, RightString, SearchOrder, int?)' path='/param[@name="searchOrder"]'/>
        /// </summary>
        /// <value></value>
        public SearchOrder SearchOrder { get; set; }
        /// <summary>
        /// <inheritdoc cref='StringExtractorParameters(string, LeftString, RightString, SearchOrder, int?)' path='/param[@name="startIndex"]'/>
        /// </summary>
        /// <value></value>
        public int? StartIndex { get; set; }
    }
}
