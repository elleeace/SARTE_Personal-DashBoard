using System.Windows;
using System.Windows.Controls;

namespace SARTE_Personal_DashBoard.Pages
{
    public partial class Favorites : Page
    {
        public Favorites()
        {
            InitializeComponent();
        }

        private void BigPaintingPrice(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string tag = clickedButton.Tag.ToString();
                string[] parts = tag.Split(',');

                if (parts.Length == 3)
                {
                    string imageSource = parts[1]; // The image source
                    string price = parts[2]; // The price
                    string artName = parts[0];
                    OpenImagePopup(imageSource, artName, price);
                }
            
            }
        }

        private void CustomPaint(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string tag = clickedButton.Tag.ToString();
                string[] parts = tag.Split(',');

                if (parts.Length == 3)
                {
                    string imageSource = parts[1]; // The image source
                    string price = parts[2]; // The price
                    string artName = parts[0];
                    OpenImagePopup(imageSource, artName, price);
                }
            }
        }

        private void OpenImagePopup(string imageSource, string artName, string price)
        {
            PopUp popup = new PopUp(imageSource, artName, price);
            popup.ShowDialog(); // Show the popup as a dialog
        }
    }
}