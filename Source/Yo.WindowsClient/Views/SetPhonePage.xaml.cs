using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Yo.Models.ViewModels;
using Yo.WindowsClient.ViewModels;

namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for SetPhonePage.xaml
    /// </summary>
    public partial class SetPhonePage : Page
    {
        private readonly UserViewModel user;

        public SetPhonePage(UserViewModel user)
        {
            InitializeComponent();
            this.user = user;
            this.DataContext = new SetPhonePageViewModel(this.user);
        }
    }
}
