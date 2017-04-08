namespace RegexFileSearch.Contracts
{
    using System;

    /// <summary>
    /// Implenet to show progress.
    /// </summary>
    public interface IProgress
    {
        /// <summary>
        /// Event for line processed.
        /// </summary>
        event EventHandler<LineProcessedEventArgs> LineProcessed;
    }
}
