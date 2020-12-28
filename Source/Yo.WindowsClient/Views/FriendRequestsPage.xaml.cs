using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Yo.Models.ViewModels;
using Yo.WindowsClient.ViewModels;

namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for FriendRequestsPage.xaml
    /// </summary>
    public partial class FriendRequestsPage : Page
    {
        private UserViewModel user;

        public FriendRequestsPage(UserViewModel user)
        {
            InitializeComponent();
            this.user = user;
            this.DataContext = new FriendRequestsViewModel(this.user);
        }
    }
}
