namespace RegexFileSearch.SearchAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using RegexFileSearch.Contracts;

    /// <summary>
    /// Searcher using parallel features.
    /// </summary>
    public class ParallelSearcher : ISearcher, IProgress
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
            int linesCount = File.ReadAllLines(config.FilePath).Length;

            await Task.Run(() =>
            {
                ProcessFile(config, results, lineNumber, linesCount);
            });

            return results.Count;
        }

        private void ProcessFile(SearchConfig config, List<string> results, int lineNumber, int linesCount)
        {
            var lines = File.ReadLines(config.FilePath);

            int count = 0;

            var countLock = new Object();

            Parallel.ForEach(lines, line =>
            {
                var match = config.SearchPattern.Match(line);

                results.Add(match.Groups[0].Value);

                lock (countLock)
                {
                    count++;
                }

                OnLineProcessesed(new LineProcessedEventArgs { LineNumber = count, TotalCount = linesCount });

            });
        }

        public event EventHandler<LineProcessedEventArgs> LineProcessed;

        protected virtual void OnLineProcessesed(LineProcessedEventArgs e)
        {
            LineProcessed?.Invoke(this, e);
        }
    }
}