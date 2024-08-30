using Microsoft.Win32;
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

namespace Login
{
    /// <summary>
    /// Interaction logic for diary.xaml
    /// </summary>
    public partial class diary : Page
    {
        public diary()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Document|*.txt|Document|*.docx";
            openFile.Title = "Open";
            openFile.ShowDialog();
            string Readfile = openFile.FileName;
            txtcontent.Text = File.ReadAllText(Readfile);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Document|*.txt";
            saveFile.Title = "Save";
            saveFile.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            txtcontent.Clear();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            btnsave.Background = Brushes.Green;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            btnsave.Background = Brushes.Red;
        }
    }
}
