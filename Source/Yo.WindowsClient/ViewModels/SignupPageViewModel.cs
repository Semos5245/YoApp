using System;
using System.Text;
using System.Threading.Tasks;
using Yo.WindowsClient.Views;
using Yo.Api.Client.Models;
using Yo.Models.ViewModels;
using System.Windows.Input;
using Yo.WindowsClient.Models;
using System.Security.Cryptography;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Yo.WindowsClient.ViewModels
{
    public class SignupPageViewModel : BaseViewModel
    {
        #region Private Fields
        
        private string username = string.Empty;
        private string password = string.Empty;

        #endregion

        #region Constructor

        public SignupPageViewModel() { }

        #endregion

        #region Public Properties

        public string Username
        {
            get
            {
                return username;
            }
            set { username = value; OnPropertyChanged(); Message = string.Empty; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); Message = string.Empty; }
        }

        #endregion

        #region Commands

        public ICommand SignupCommand
        {
            get => new Command(async () => await Signup());
        }

        public ICommand BackCommand
        {
            get => new Command(() => Back());
        }

        #endregion

        #region Methods

        private void Back()
        {
            PagesSwitcher.SwitchToPage(new MainPage());
        }

        private async Task Signup()
        {
            //Get busy doing the task
            IsBusy = true;

            //Check if the username or password are empty
            if (Username.Equals(string.Empty) || Password.Equals(string.Empty))
            {
                Message = "Username or password can't be empty.";
            }
            else
            {
                //Hash Password
                byte[] inputBytes = Encoding.ASCII.GetBytes(Password);
                MD5 hasher = MD5.Create();
                byte[] hashBytes = hasher.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                //Create a model for the request
                SignUpUserViewModel model = new SignUpUserViewModel
                {
                    Username = Username,
                    Password = sb.ToString()
                };

                try
                {
                    //Send the model
                    var response = await User.SignUpUserAsync(model);

                    //Check the response
                    if (response.Status.Equals("Success"))
                    {
                        IsBusy = false;

                        //Open the friends page with the received user
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
                    Message = "An Error has occured.";
                    MessageColor = Brushes.Red;
                    PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                    PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                    PopupOpened = true;

                }
            }

            IsBusy = false;
        }

        #endregion
    }
}
