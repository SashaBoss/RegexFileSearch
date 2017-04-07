using System;
using System.Linq;
using System.Threading.Tasks;

namespace RegexFileSearch
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The linear searcher.
    /// </summary>
    public class LinearSearcher : ISearcher, IProgress
    {
        /// <summary>
        /// Search by regex line by line,
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> Search(SearchConfig config)
        {
            var results = new List<string>();
            int lineNumber = 1;
            int linesCount = File.ReadAllLines(config.FilePath).Length;

            await Task.Run(() =>
            {
                ProcessFile(config, results, lineNumber, linesCount);
            });

            return results;
        }

        private void ProcessFile(SearchConfig config, List<string> results, int lineNumber, int linesCount)
        {
            using (StreamReader r = new StreamReader(config.FilePath))
            {
                string line;

                while ((line = r.ReadLine()) != null)
                {
                    var matches = config.SearchPattern.Matches(line);

                    results.AddRange(from object match in matches select match.ToString());

                    OnLineProcessesed(new LineProcessedEventArgs { LineNumber = lineNumber, TotalCount = linesCount });

                    lineNumber++;
                }
            }
        }

        public event EventHandler<LineProcessedEventArgs> LineProcessed;

        protected virtual void OnLineProcessesed(LineProcessedEventArgs e)
        {
            LineProcessed?.Invoke(this, e);
        }
    }
}