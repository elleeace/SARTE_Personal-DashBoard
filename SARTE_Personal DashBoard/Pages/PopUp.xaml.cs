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
using System.Windows.Shapes;

namespace SARTE_Personal_DashBoard.Pages
{
    /// <summary>
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : Window
    {
        public PopUp(string imageSource, string artworkName, string price)
        {
            InitializeComponent();
            imgArt.Source = new BitmapImage(new Uri(imageSource, UriKind.RelativeOrAbsolute));
            tbArtworkName.Text = artworkName;
            tbPrice.Text = price;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please visit elleekabook.com to purchase the actual product");
        }
    }
}
