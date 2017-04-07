using System.Threading.Tasks;

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
        /// <summary>
        /// Parralel searching algorithm.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public Task<IEnumerable<string>> Search(SearchConfig config)
        {
            throw new NotImplementedException();
        }
    }
}