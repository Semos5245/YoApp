using System.Windows;
using System.Windows.Controls;

namespace Yo.WindowsClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Models.WindowBoundaryProvider.SetWindowBoundary(this.Width, this.Height);
            Models.PagesSwitcher.SetMainWindow(this);
            Models.PagesSwitcher.SwitchToPage(new Views.MainPage());
            this.SizeChanged += UpdateWindowBoundaryValues;
        }

        private void UpdateWindowBoundaryValues(object sender, RoutedEventArgs args)
        {
            Models.WindowBoundaryProvider.SetWindowBoundary(this.Width, this.Height);
        }
    }
}
