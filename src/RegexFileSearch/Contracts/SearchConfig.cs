namespace RegexFileSearch.Contracts
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represent config for search by regex.
    /// </summary>
    public class SearchConfig
    {
        /// <summary>
        /// Gets or sets fill path.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets regular expression.
        /// </summary>
        public Regex SearchPattern { get; set; }
    }
}
