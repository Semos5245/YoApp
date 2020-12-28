using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Yo.Models.ViewModels;
using Yo.WindowsClient.ViewModels;

namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for EditProfilePage.xaml
    /// </summary>
    public partial class EditProfilePage : Page
    {
        private readonly UserViewModel user;

        public EditProfilePage(UserViewModel user)
        {
            InitializeComponent();
            this.user = user;
            this.DataContext = new EditProfilePageViewModel(this.user);
        }
    }
}
