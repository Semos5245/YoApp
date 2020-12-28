using System.Windows;
using System.Windows.Controls;

namespace Yo.WindowsClient.Models
{
    public static class PagesSwitcher
    {
        private static MainWindow mainWindow;

        public static void SetMainWindow(Window window)
        {
            mainWindow = (MainWindow)window;
        }

        public static void SwitchToPage(Page page)
        {
            mainWindow.Content = page;
        }
    }
}
