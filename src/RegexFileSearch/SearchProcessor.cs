using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexFileSearch
{
    /// <summary>
    /// The search processor.
    /// </summary>
    public class SearchProcessor: ISearcher
    {
        /// <summary>
        /// Represent searching algorithm.
        /// </summary>
        private readonly ISearcher _searcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchProcessor"/>
        /// </summary>
        /// <param name="searchAlghorithm"></param>
        public SearchProcessor(ISearcher searchAlghorithm)
        {
            this._searcher = searchAlghorithm;
        }

        /// <summary>
        /// Search by regex using provided searching algo.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> Search(SearchConfig config)
        {
            return await _searcher.Search(config);
        }
    }

}
