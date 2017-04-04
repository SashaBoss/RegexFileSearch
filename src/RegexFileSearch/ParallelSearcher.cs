namespace RegexFileSearch
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Searcher using parallel features.
    /// </summary>
    public class ParallelSearcher : ISearcher
    {
        public IEnumerable<string> Search(string filePath, Regex regexPattern)
        {
            throw new NotImplementedException();
        }
    }
}
