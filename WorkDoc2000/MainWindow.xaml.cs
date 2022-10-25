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
            FileInfo fi = new FileInfo(@"WorkDoc2000.txt");
            if (fi.Exists)
            {
                FileStream fs = fi.Open(FileMode.Append, FileAccess.Write, FileShare.Read);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(myTextBox.Text);
                sw.Close();
                fs.Close();
            }
            else
            {
                FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(myTextBox.Text);
                sw.Close();
                fs.Close();
            }
            myTextBox.Text = String.Empty;
        }

        private void ReadText_Click(object sender, RoutedEventArgs e)
        {
            FileInfo fi = new FileInfo(@"WorkDoc2000.txt");
            FileStream fs = fi.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader sr = new StreamReader(fs);
            string toTextBox = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            myTextBox.Text = toTextBox;
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
            string output = input.Replace('a', '4').Replace('A', '4').Replace('e', '3').Replace('E', '3');
            myTextBox.Text = output;
        }
    }
}
