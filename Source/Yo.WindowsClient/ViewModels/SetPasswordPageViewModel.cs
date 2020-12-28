using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Yo.WindowsClient.Models;
using Yo.WindowsClient.Views;
using System.Security.Cryptography;
using System.Windows.Media;
using Yo.Models.ViewModels;
using System.Windows.Controls.Primitives;

namespace Yo.WindowsClient.ViewModels
{
    public class SetPasswordPageViewModel : BaseViewModel
    {
        #region Private Fields
        
        private UserViewModel user;
        private string newPassword = string.Empty;
        private string verifyPassword = string.Empty;

        #endregion

        #region Constructor

        public SetPasswordPageViewModel(UserViewModel user)
        {
            this.User = user;
        }

        #endregion

        #region Public Properties
        
        public UserViewModel User
        {
            get { return user; }
            set { user = value; }
        }

        public string NewPassword
        {
            get { return newPassword; }
            set { newPassword = value.Trim(); OnPropertyChanged(); }
        }

        public string VerifyPassword
        {
            get { return verifyPassword; }
            set { verifyPassword = value.Trim(); OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public ICommand SetPasswordCommand
        {
            get => new Command(async () => await SetPassword());
        }

        public ICommand CancelCommand
        {
            get => new Command(() => Cancel());
        }

        #endregion

        #region Methods

        private async Task SetPassword()
        {
            IsBusy = true;

            //Password empty
            if (string.IsNullOrEmpty(NewPassword) || string.IsNullOrEmpty(VerifyPassword))
            {
                //Popup an error
                Message = "Password can't be empty.";
                MessageColor = Brushes.Red;
                PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                PopupOpened = true;
                
            }

            //Check if the passwords match
            else if (!NewPassword.Equals(VerifyPassword))
            {
                //Popup an error
                Message = "Passwords do not match!";
                MessageColor = Brushes.Red;
                PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                PopupOpened = true;
                
            }
            else
            {
                //Hash password
                byte[] inputBytes = Encoding.ASCII.GetBytes(NewPassword);
                MD5 hasher = MD5.Create();
                byte[] hashBytes = hasher.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                try
                {
                    //Send request to change the password
                    var response = await Yo.Api.Client.Models.User.ChangePasswordAsync(User.UserId, sb.ToString());

                    //Check response status
                    if (response.Status.Equals("Success"))
                    {
                        Message = "Password has been updated.";
                    }
                    else
                    {
                        //Popup an error
                        Message = "An Error has occured at the server. Please try again later.";
                        MessageColor = Brushes.Red;
                        PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                        PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                        PopupOpened = true;
                        
                    }
                }
                catch(Exception e)
                {
                    //Popup an error
                    Message = "An Error has occured. Please try again later.";
                    MessageColor = Brushes.Red;
                    PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                    PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                    PopupOpened = true;
                    
                }
            }

            IsBusy = false;
        }

        private void Cancel()
        {
            PagesSwitcher.SwitchToPage(new SettingsPage(User));
        }

        #endregion
    }
}
