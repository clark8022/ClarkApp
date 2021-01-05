using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ClarkApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string[] _linesArray;
        int _currentIndex = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRunTest_Click(object sender, RoutedEventArgs e)
        {
            Test();
        }

        private void Test()
        {
            try
            {
                string key = "WordsPuzzles01";
                txtbShow.FontSize = 288;
                if (rb1.IsChecked != null && (bool)rb1.IsChecked)
                {
                    key = "WordsPuzzles01";
                }
                else if (rb2.IsChecked != null && (bool)rb2.IsChecked)
                {
                    key = "WordsPuzzles02";
                }
                else if (rb3.IsChecked != null && (bool)rb3.IsChecked)
                {
                    key = "WordsPuzzles03";
                }
                else if (rb4.IsChecked != null && (bool)rb4.IsChecked)
                {
                    key = "WordsPuzzles04";
                }
                else if (rb5.IsChecked != null && (bool)rb5.IsChecked)
                {
                    key = "Punishment";
                    txtbShow.FontSize = 144;
                }
                string path = GetSetting(key);
                IEnumerable<string> lines = File.ReadLines(path);
                if (lines != null)
                {
                    _linesArray = lines.ToArray();
                }
                txtRichInfo.AppendText(string.Format("Words of puzzles {0} loading done!", path));
                _currentIndex = -1;
                txtbShow.Text = "Go!";
            }
            catch (Exception ex)
            {
                txtRichInfo.AppendText(ex.Message);
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_linesArray != null && _linesArray.Length > _currentIndex + 1 && _currentIndex >= -1)
            {
                txtbShow.Text = _linesArray[++_currentIndex];
            }
        }

        private string GetSetting(string appSettingsKey)
        {
            string setting = ConfigurationManager.AppSettings[appSettingsKey];

            return setting;
        }
        private void ShowMessageBox(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButton.OK);
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (_linesArray != null && _linesArray.Length > _currentIndex && _currentIndex > 0)
            {
                txtbShow.Text = _linesArray[--_currentIndex];
            }
        }

        private void btnPunish_Click(object sender, RoutedEventArgs e)
        {
            _currentIndex = Int32.Parse(txtInput.Text.Trim());
            if (_currentIndex < _linesArray.Length)
            {
                txtbShow.Text = _linesArray[_currentIndex];
            }
            else
            {
                txtRichInfo.AppendText(string.Format("Current Index: {0}, Array Length:{1}, please input a number less than {1}.", _currentIndex, _linesArray.Length));
            }
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if (_linesArray != null)
            {
                txtRichInfo.AppendText(string.Format("Current Index: {0}, Array Length:{1}", _currentIndex, _linesArray.Length));
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Key == Key.Down || e.Key == Key.Right || e.Key == Key.PageDown)
            {
                btnNext_Click(null, null);
            }
            else if (e.Key == Key.Up || e.Key == Key.Left || e.Key == Key.PageUp)
            {
                btnPrevious_Click(null, null);
            }
        }
    }
}
