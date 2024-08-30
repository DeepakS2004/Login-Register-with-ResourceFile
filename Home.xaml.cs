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
using System.Windows.Shapes;

namespace Login
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        diary contentpage;
        create createpage;
        list listpage;
        public Home()
        {
            InitializeComponent();
            contentpage = new diary();
            createpage = new create();
            listpage = new list();
        }

       
        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
           MainWindow omainWindow = new MainWindow();
            this.Close();
            omainWindow.Show();
        }

      
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainframe.Content = createpage;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            mainframe.Content = contentpage ;
        }

       
    }
}
