using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Yo.WindowsClient.Models
{
    public static class PopupHelper
    {
        public static void InitializeAndPopup(this Popup popup, double width, double height, string message, SolidColorBrush foreground)
        {
            //Set Width and height of the popup
            popup.Width = width;
            popup.Height = height;
            
            //Get the inner components
            var grid = popup.Child as Grid;
            var innerTextBlock = grid.Children[1] as TextBlock;

            //Set the message properties
            innerTextBlock.Text = message;
            innerTextBlock.Foreground = foreground;

            //Make the popup visibile
            popup.IsOpen = true;
        }
    }
}
