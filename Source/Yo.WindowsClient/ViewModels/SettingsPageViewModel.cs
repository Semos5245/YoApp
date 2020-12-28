using System.Windows.Input;
using Yo.WindowsClient.Models;
using Yo.WindowsClient.Views;
using Yo.Models.ViewModels;
using System.Windows.Controls.Primitives;

namespace Yo.WindowsClient.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        #region Private Fields
        
        private UserViewModel user;
        private LogoutWindow logoutWindow;

        #endregion

        #region Constructor

        public SettingsPageViewModel(UserViewModel user)
        {
            this.User = user;
            this.logoutWindow = new LogoutWindow();
        }

        #endregion

        #region Public Properties
        
        public UserViewModel User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public string YoCount
        {
            get => User.YosCount.ToString();
        }

        public string Username
        {
            get => User.Username;
        }
        #endregion

        #region Commands

        public ICommand OpenSetPasswordPageCommand
        {
            get => new Command(() => OpenSetPasswordPage());
        }

        public ICommand OpenSetEmailPageCommand
        {
            get => new Command(() => OpenSetEmailPage());
        }

        public ICommand OpenSetPhonePageCommand
        {
            get => new Command(() => OpenSetPhonePage());
        }

        public ICommand OpenEdiProfilePageCommand
        {
            get => new Command(() => OpenEdiProfilePage());
        }

        public ICommand OpenBlockedFriendsPageCommand
        {
            get => new Command(() => OpenBlockedFriendsPage());
        }

        public ICommand BackCommand
        {
            get => new Command(() => Back());
        }

        public ICommand OpenLogoutWindowCommand
        {
            get => new Command(() => OpenLogoutWindow());
        }

        #endregion

        #region Methods

        private void OpenSetPasswordPage()
        {
            PagesSwitcher.SwitchToPage(new SetPasswordPage(User));
        }

        private void OpenSetEmailPage()
        {
            PagesSwitcher.SwitchToPage(new SetEmailPage(User));
        }

        private void OpenSetPhonePage()
        {
            PagesSwitcher.SwitchToPage(new SetPhonePage(User));
        }

        private void OpenEdiProfilePage()
        {
            PagesSwitcher.SwitchToPage(new EditProfilePage(User));
        }

        private void OpenBlockedFriendsPage()
        {
            PagesSwitcher.SwitchToPage(new BlockedFriendsPage(User));
        }

        private void Back()
        {
            PagesSwitcher.SwitchToPage(new FriendsPage(User));
        }

        private void OpenLogoutWindow()
        {
            this.logoutWindow.ShowDialog();
        }

        #endregion
    }
}
