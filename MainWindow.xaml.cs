using System.Globalization;
using System.IO;
using System.Windows;


namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            if (string.IsNullOrEmpty(Settings1.Default.lang))
            {
                CultureInfo display = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = display;
            }
            else
            {
                CultureInfo display = new CultureInfo(Settings1.Default.lang);
                Thread.CurrentThread.CurrentUICulture = display;
            }
            InitializeComponent();
        }
       
        string rootpath = Settings1.Default.root;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         

            if (string.IsNullOrEmpty(rootpath))
            {
                string directory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory + "\\Data");
                }
                else
                {
                    MessageBox.Show("Already Exist");
                }
                Settings1.Default.root = directory + "\\Data";
                Settings1.Default.Save();
            }
            Register oRegister = new Register();
            this.Close();
            oRegister.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            string userpath = System.IO.Path.Combine(rootpath, txtusername.Text);
            if (Directory.Exists(userpath) == false)
            {
                MessageBox.Show("Username and Password Invalid");
            }
            else
            {
                string userfile = Path.Combine(userpath, "userdata.txt");
                if (File.Exists(userfile) == false)
                {
                    MessageBox.Show("Username and Password Invalid");
                }
                else
                {
                    string value = File.ReadAllText(userfile);
                    string[] listvalue = value.Split("|"); 
                    if (listvalue.Length > 2)
                    {
                        if (pwbox.Password == listvalue[1])
                        {
                            MessageBox.Show("Valid User");
                            //Home ohome = new Home();
                            //this.Close(); 
                            //ohome.Show();
                            Register oregister = new Register(listvalue);
                            oregister.Show();
                        }
                        else
                        {
                            MessageBox.Show("Username and Password Invalid");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username and Password Invalid");
                    }

                }
            }
            
        }

        private void lang1bn_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo display = new CultureInfo("ta-IN");
            Thread.CurrentThread.CurrentUICulture = display;
            Settings1.Default.lang = "ta-IN";
            Settings1.Default.Save();

        }

        private void lang2bn_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo display = new CultureInfo("hi-IN");
            Thread.CurrentThread.CurrentUICulture = display;
            Settings1.Default.lang = "hi-IN";
            Settings1.Default.Save();

        }

        private void lang3bn_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo display = new CultureInfo("te-IN");
            Thread.CurrentThread.CurrentUICulture = display;
            Settings1.Default.lang = "te-IN";
            Settings1.Default.Save();

        }

        private void lang4bn_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo display = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = display;
            Settings1.Default.lang = "en-US";
            Settings1.Default.Save();

        }
    }
}