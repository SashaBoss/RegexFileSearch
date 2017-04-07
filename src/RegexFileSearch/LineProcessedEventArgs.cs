namespace RegexFileSearch
{
    using System;

    /// <summary>
    /// Event args for one line processed of total.
    /// </summary>
    public class LineProcessedEventArgs : EventArgs
    {
        public int LineNumber { get; set; }
        public int TotalCount { get; set; }
    }
}
