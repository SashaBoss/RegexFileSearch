using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexFileSearch
{
    public class SearchProcessor : IRegexSearch
    {
        private readonly ISearcher _searcher;

        public SearchProcessor()
        {
            _searcher = new ParallelSearcher();
        }

        public IEnumerable<string> Search(SearchConfig controller)
        {
            return _searcher.Search(controller.FilePath, controller.Regex);
        }
    }

}
