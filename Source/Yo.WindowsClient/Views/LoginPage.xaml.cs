using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Yo.WindowsClient.ViewModels;

namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            this.DataContext = new LoginPageViewModel();
        }
    }
}
