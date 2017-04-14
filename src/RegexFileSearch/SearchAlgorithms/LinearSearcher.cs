namespace RegexFileSearch.SearchAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using RegexFileSearch.Contracts;

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
        public async Task<int> Search(SearchConfig config)
        {
            var results = new List<string>();
            int lineNumber = 1;

            await Task.Run(() =>
            {
                ProcessFile(config, results, lineNumber);
            });

            return results.Count;
        }

        private void ProcessFile(SearchConfig config, List<string> results, int lineNumber)
        {
            int linesCount = File.ReadAllLines(config.FilePath).Length;

            using (StreamReader r = new StreamReader(config.FilePath))
            {
                string line;

                while ((line = r.ReadLine()) != null)
                {
                    var match = config.SearchPattern.Match(line);

                    if (match.Success)
                    {
                        results.Add(match.Groups[0].Value);
                    }

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