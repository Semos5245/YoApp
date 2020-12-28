using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Yo.Models.ViewModels;
using Yo.WindowsClient.ViewModels;
namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for SetEmailPage.xaml
    /// </summary>
    public partial class SetEmailPage : Page
    {
        private readonly UserViewModel user;

        public SetEmailPage(UserViewModel user)
        {
            InitializeComponent();
            this.user = user;
            this.DataContext = new SetEmailPageViewModel(this.user);
        }
    }
}
