using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;


namespace WorkDoc2000
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] antalOrd = new string[100];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void antalOrdBtn_Click(object sender, RoutedEventArgs e)
        {
            string inputText = myTextBox.Text;  
            antalOrd = inputText.Split(' ','(',')');
            myTextBox.Text = antalOrd.Count().ToString();

        }

        private void loadFileBtn_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text file (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string fileName = dlg.FileName;
                string read = "";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    read = sr.ReadToEnd();
                }
                myTextBox.Text = read;
            }
        }

        private void skrivFileBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "skrivIFil";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "text file (.txt)|*.txt";
            //dlg.InitialDirectory = @"D:\ITHS_Repositories";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string fileName = dlg.FileName;
                using (StreamWriter sw = new StreamWriter($"{fileName}.html"))
                {
                    sw.WriteLine(myTextBox.Text);
                }
                MessageBox.Show($"Saved as {fileName}");
            }
        }

        private void transformBtn_Click(object sender, RoutedEventArgs e)
        {
            string inputText = myTextBox.Text;
            myTextBox.Text = inputText.ToUpper();
        }

        private void formatTxt_Click(object sender, RoutedEventArgs e)
        {
            string inputText = myTextBox.Text;
            string[] mening = inputText.Split(new string[] {". ","\r\n","\r","\n"},StringSplitOptions.None);
            //string[] mening = Regex.Split(inputText, @"([.\s]|[\r|\n|\r\n] )");
            string inputText2 = string.Empty;
            foreach (string str in mening)
            {
                if (char.IsUpper(str.First()))
                    inputText2 = str;
                else if (str.EndsWith('.'))
                    inputText2 += str;
                else
                inputText2 +=  str.First().ToString().ToUpper() + str.Substring(1) + ". ";
            }
            //inputText2 = mening.Select(m => m[0].ToString().ToUpper() + m.Substring(1).ToLower());
            myTextBox.Text = inputText2;

        }

        private void chancheTxt_Click(object sender, RoutedEventArgs e)
        {
            myTextBox.Text = myTextBox.Text.Replace('e', '3').Replace('a', '4').Replace('s', '5');
        }
        //public static String CapitalizeAndStuff(string startingString)
        //{
        //    startingString = startingString.ToLower();
        //    char[] chars = new[] { '.' };
        //    StringBuilder result = new StringBuilder(startingString.Length);
        //    bool makeUpper = true;
        //    foreach (var c in startingString)
        //    {
        //        if (makeUpper)
        //        {
        //            result.Append(Char.ToUpper(c));
        //            makeUpper = false;
        //        }
        //        else
        //        {
        //            result.Append(c);
        //        }
        //        if (chars.Contains(c))
        //        {
        //            makeUpper = true;
        //        }
        //    }
        //    return result.ToString();
        //}
    }
}
