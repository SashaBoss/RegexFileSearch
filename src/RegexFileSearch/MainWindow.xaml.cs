using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            GetFilePath();
        }

        private void GetFilePath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog(this);
            filePath.Text = dialog.FileName;
            SearchConfig.FilePath = dialog.FileName;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            IRegexSearch searcher = new SearchProcessor();

            var result = searcher.Search(SearchConfig);
        }
    }
}
