using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Yo.WindowsClient.ViewModels;

namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new MainPageViewModel();
        }
    }
}
