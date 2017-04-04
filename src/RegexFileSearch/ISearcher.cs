namespace RegexFileSearch
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Search by regex in file.
    /// </summary>
    interface ISearcher
    {
        /// <summary>
        /// Search in file using specified regex.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="regexPattern"></param>
        /// <returns></returns>
        IEnumerable<string> Search(string filePath, Regex regexPattern);
    }
}
