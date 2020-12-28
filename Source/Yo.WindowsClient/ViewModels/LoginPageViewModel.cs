using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Yo.Models.ViewModels;
using Yo.WindowsClient.Models;
using Yo.WindowsClient.Views;

namespace Yo.WindowsClient.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Private Fields
        
        private string username;
        private string password;

        #endregion

        #region Constructor

        public LoginPageViewModel() { }

        #endregion

        #region Public Properties
        
        public string Username
        {
            get { return username; }
            set { username = value.Trim(); OnPropertyChanged(); }
        }

        public string Password
        {
            get { return password; }
            set { password = value.Trim(); OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand
        {
            get { return new Command(async () => await LoginUser()); }
        }

        public ICommand BackCommand
        {
            get { return new Command(() => GetBack()); }
        }

        #endregion

        #region Methods

        private async Task LoginUser()
        {
            IsBusy = true;

            //Hash Password
            byte[] inputBytes = Encoding.ASCII.GetBytes(Password);
            MD5 hasher = MD5.Create();
            byte[] hashBytes = hasher.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            //Create the sign in model
            SignInUserViewModel model = new SignInUserViewModel
            {
                Username = this.Username.Trim(),
                Password = sb.ToString()
            };

            try
            {
                //Send a sign in request
                var response = await Yo.Api.Client.Models.User.SignInUserAsync(model);

                //Check response
                if (response.Status.Equals("Success"))
                {
                    IsBusy = false;
                    PagesSwitcher.SwitchToPage(new FriendsPage(response.User));
                }
                else
                {
                    //Popup an error
                    Message = response.Message;
                    MessageColor = Brushes.Red;
                    PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                    PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                    PopupOpened = true;
                }
            }
            catch(Exception e)
            {
                //Popup an error
                Message = "An error has occured. Please try again later";
                MessageColor = Brushes.Red;
                PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                PopupOpened = true;
            }

            IsBusy = false;
        }

        //Return to the Main Page
        private void GetBack()
        {
            PagesSwitcher.SwitchToPage(new MainPage());
        }

        #endregion
    }
}
