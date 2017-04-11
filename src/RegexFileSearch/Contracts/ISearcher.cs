using System.Threading.Tasks;
using RegexFileSearch.Contracts;

namespace RegexFileSearch
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Search by regex in file.
    /// </summary>
    public interface ISearcher
    {
        /// <summary>
        /// Search in file using specified regex.
        /// </summary>
        /// <param name="searchConfig"></param>
        /// <returns></returns>
        Task<int> Search(SearchConfig searchConfig);
    }
}
