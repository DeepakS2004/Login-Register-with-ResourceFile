using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;

namespace Login
{

    public partial class Register : Window
    {

        public Register(string[] userdata)
        {
            InitializeComponent();
            string[] city = { "Chennai", "Coimbatore", "Salem", "Dharmapuri", "Tirupur" };


            if (userdata.Length > 5)
            {
                txtname.IsReadOnly = true;
                btnreg.Content = "Update";
                txtname.Text = userdata[0];
                createpw.Password = userdata[1];
                foreach (RadioButton radio in spgender.Children)
                {
                    if (radio.Content.ToString() == userdata[2])
                    {
                        radio.IsChecked = true;
                    }
                }
                txtphn.Text = userdata[3];
                txtemail.Text = userdata[4];
                foreach (CheckBox check in spskill.Children)
                {
                    string[] skill = userdata[5].Split(',');
                    for (int i = 0; i < skill.Length; i++)
                    {
                        if (check.Content.ToString() == skill[i])
                        {
                            check.IsChecked = true;
                        }
                    }
                }
                cmbcity.ItemsSource = city;
                cmbcity.SelectedItem = userdata[6].Trim();
                //foreach (object item in cmbcity.Items)
                //{
                //    if (item.ToString() == userdata[6])
                //    {
                //        cmbcity.SelectedItem = item;
                //    }
                //}

            }
        }
        public Register()
            {
            InitializeComponent ();
            string[] city = { "Chennai", "Coimbatore", "Salem", "Dharmapuri", "Tirupur" };
            cmbcity.ItemsSource = city;
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                string rootpath = Settings1.Default.root;
                string username = rootpath + "\\" + txtname.Text;

                if (Directory.Exists(username))
                {
                    MessageBox.Show("Already Exist");
                }
                else
                {
                    string gender = "";
                    foreach (RadioButton item in spgender.Children)
                    {
                        if (item.IsChecked == true)
                        {
                            gender = item.Content.ToString();
                        }
                    }
                    string skill = "";
                    foreach (CheckBox check in spskill.Children)
                    {
                        if (check.IsChecked == true)
                        {
                            if (!string.IsNullOrEmpty(skill))
                            {
                                skill = skill + "," + check.Content.ToString();
                            }
                            else
                            {
                                skill = check.Content.ToString();
                            }

                        }
                    }
                    Directory.CreateDirectory(rootpath + "\\" + txtname.Text);
                    string data = $"{txtname.Text}|{createpw.Password}|{gender}|{txtphn.Text}|{txtemail.Text}|" + $"{skill}|{cmbcity.SelectedItem.ToString()} ";
                    File.WriteAllText(username + "\\userdata.txt", data);

                    ResourceManager resource = new ResourceManager("Login.language.Resourcefile", Assembly.GetExecutingAssembly());
                    MessageBox.Show(resource.GetString("registersuccessfully"), "JSQUARE",
                                   MessageBoxButton.OK);
                }

                MainWindow oMainWindow = new MainWindow();
                this.Close();
                oMainWindow.Show();
            }




        
    }
}