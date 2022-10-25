using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WorkDoc2000
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WordCounter_Click(object sender, RoutedEventArgs e)
        {
            string[] inputArr = myTextBox.Text.Split(' ', '\n');
            List<string> inputList = new List<string>();



            foreach (string str in inputArr)
            {
                inputList.Add(str);
            }



            int count = inputList.Count();



            //MessageBox.Show(count.ToString());
            MessageBox.Show(count.ToString(), "Ordräknaren", MessageBoxButton.OK);

        }

        private void SaveText_Click(object sender, RoutedEventArgs e)
        {           
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "WorkDoc2000";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string fileName = dlg.FileName;
                using (StreamWriter sw = new StreamWriter($"{fileName}"))
                {
                    sw.WriteLine(myTextBox.Text);
                }                
            }
            myTextBox.Text = String.Empty;
        }

        private void ReadText_Click(object sender, RoutedEventArgs e)
        {    
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "WorkDoc2000"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by ex
                                                        // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string fileName = dlg.FileName;
                string toTextBox = " ";
                using(StreamReader sr = new StreamReader(fileName))
                {
                    toTextBox = sr.ReadToEnd();
                }
                myTextBox.Text = toTextBox;

            }
        }

        private void CapitalLetterAfterDOT_Click(object sender, RoutedEventArgs e)
        {
            string[] Arr = myTextBox.Text.Split('.');
            for (int i = 0; i < Arr.Length - 1; i++)
            {
                Arr[i] = Arr[i].Trim();
                Arr[i] = Arr[i].Substring(0, 1).ToUpper() + Arr[i].Substring(1);
                if (i > 0)
                    Arr[i] = Arr[i].Insert(0, ". ");
            }



            myTextBox.Text = (Arr.Aggregate((a, b) => a + b)) + ".";
        }

        private void LEETspeak_Click(object sender, RoutedEventArgs e)
        {
            string input = myTextBox.Text;
            string output = input.Replace('a', '4').Replace('A', '4').Replace('e', '3').Replace('E', '3').Replace('s','5').Replace('s','5').Replace('i','1').Replace('i','1').Replace('o', '0').Replace('O', '0').Replace('z', '2').Replace('Z', '2').Replace('b', '6').Replace('B', '8');
            myTextBox.Text = output;
        }
    }
}
