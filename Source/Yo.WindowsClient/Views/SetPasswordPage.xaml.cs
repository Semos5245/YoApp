using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Yo.Models.ViewModels;
using Yo.WindowsClient.ViewModels;

namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for SetPasswordPage.xaml
    /// </summary>
    public partial class SetPasswordPage : Page
    {
        private readonly UserViewModel user;

        public SetPasswordPage(UserViewModel user)
        {
            InitializeComponent();
            this.user = user;
            this.DataContext = new SetPasswordPageViewModel(this.user);
        }
    }
}
