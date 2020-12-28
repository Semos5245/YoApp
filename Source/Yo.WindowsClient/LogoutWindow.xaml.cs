using System.Windows;
using System.Windows.Controls.Primitives;

namespace Yo.WindowsClient
{
    /// <summary>
    /// Interaction logic for LogoutWindow.xaml
    /// </summary>
    public partial class LogoutWindow : Window
    {
        public LogoutWindow()
        {
            InitializeComponent();
            this.btnCancel.Click += CancelClicked;
            this.btnLogout.Click += OkClicked;
        }

        private void CancelClicked(object sender, RoutedEventArgs args)
        {
            this.Close();
        }

        private void OkClicked(object sender, RoutedEventArgs args)
        {
            this.Close();
            Models.PagesSwitcher.SwitchToPage(new Views.MainPage());
        }
    }
}
