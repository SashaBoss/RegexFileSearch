using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexFileSearch
{
    interface IRegexSearch
    {
        IEnumerable<string> Search(SearchConfig controller);
    }
}
