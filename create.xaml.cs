﻿using System;
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

namespace Login
{
    /// <summary>
    /// Interaction logic for create.xaml
    /// </summary>
    public partial class create : Page
    {
        public create()
        {
            InitializeComponent();
            string[] city = { "Chennai", "Coimbatore", "Salem", "Dharmapuri", "Tirupur" };
            cmbcity.ItemsSource = city;
        }
    }
}
