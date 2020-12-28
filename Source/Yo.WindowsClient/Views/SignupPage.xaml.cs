using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Yo.WindowsClient.ViewModels;

namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for SignupPage.xaml
    /// </summary>
    public partial class SignupPage : Page
    {
        public SignupPage()
        {
            InitializeComponent();
            this.DataContext = new SignupPageViewModel();
        }
    }
}
