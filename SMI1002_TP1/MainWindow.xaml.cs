﻿using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.OracleClient;


namespace SMI1002_TP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new PageReservation();
        }


        private void BtnClickP2(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page2();
        }

        private void BtnClickP3(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page3();
        }

        private void BtnClickPclient(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClickPreservation(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageReservation();
        }
    }
}
