using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SARTE_Personal_DashBoard.Pages
{
    /// <summary>
    /// Interaction logic for FavoritesPage.xaml
    /// </summary>
    public partial class Favorites : Page
    {
      

        public Favorites()
        {
            InitializeComponent();


        }

        private void BigPaintingPrice(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Price: 750PHP Date: 2025");
        }

        private void CustomPaint(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Price: 1000PHP Date: 2025");
        }           
    }
}
