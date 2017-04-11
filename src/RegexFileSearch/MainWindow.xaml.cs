using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using RegexFileSearch.Contracts;
using RegexFileSearch.SearchAlgorithms;

namespace RegexFileSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SearchConfig SearchConfig { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            SearchConfig = new SearchConfig();
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            SearchConfig.FilePath = ReadFilePath();
        }

        private string ReadFilePath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog(this);
            filePath.Text = dialog.FileName;

            return dialog.FileName;
        }

        private string ReadRegex()
        {
            return searchRegex.Text;
        }

        private async void searchButton_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            SearchConfig.SearchPattern = new Regex(ReadRegex());

            var linearSearcher = new LinearSearcher();
            var paralelSearcher = new ParallelSearcher();

            var searcher = new SearchProcessor(paralelSearcher);

            linearSearcher.LineProcessed += ShowProgress;
            paralelSearcher.LineProcessed += ShowProgress;

            var result = await searcher.Search(SearchConfig);

            sw.Stop();

            resultTextBox.Text = result.ToString();
            elapsed.Text = (sw.ElapsedMilliseconds / 1000).ToString();
        }

        public void ShowProgress(object sender, LineProcessedEventArgs args)
        {
            this.Dispatcher.Invoke(() =>
            {
                searchProgressBar.Value = Math.Round((double)args.LineNumber / args.TotalCount * 100);
            });
        }
    }
}
