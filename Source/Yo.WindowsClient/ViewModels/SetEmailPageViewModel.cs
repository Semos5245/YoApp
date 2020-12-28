using System;
using System.Threading.Tasks;
using Yo.WindowsClient.Views;
using System.Windows.Input;
using Yo.WindowsClient.Models;
using AKSoftware.Text;
using System.Windows.Media;
using Yo.Models.ViewModels;
using System.Windows.Controls.Primitives;

namespace Yo.WindowsClient.ViewModels
{
    public class SetEmailPageViewModel : BaseViewModel
    {
        #region Private Fields
        
        private UserViewModel user;
        private string email = string.Empty;

        #endregion

        #region Constructor

        public SetEmailPageViewModel(UserViewModel user)
        {
            this.User = user;
        }

        #endregion

        #region Public Properties

        public UserViewModel User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (!Validation.IsEmail(value))
                    Message = "Email is not valid.";
                email = value.Trim();
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand BackCommand
        {
            get => new Command(() => Cancel());
        }

        public ICommand SetEmailCommand
        {
            get => new Command(async () => await SetEmail());
        }

        #endregion

        #region Methods

        private void Cancel()
        {
            PagesSwitcher.SwitchToPage(new SettingsPage(User));
        }

        public async Task SetEmail()
        {
            IsBusy = true;

            if (!Validation.IsEmail(Email))
            {
                IsBusy = false;
                Message = "Email is not valid.";
                MessageColor = Brushes.Red;
                PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                PopupOpened = true;
            }
            else
            {
                User.Email = Email;

                try
                {
                    var model = new EditProfileInfoViewModel
                    {
                        Email = User.Email,
                        FullName = User.FullName,
                        Phone = User.Phone,
                        UserId = User.UserId
                    };

                    var response = await Yo.Api.Client.Models.User.EditProfileAsync(model);

                    if (response.Status.Equals("Success"))
                    {
                        IsBusy = false;
                        Message = "Email has been updated.";
                        PagesSwitcher.SwitchToPage(new SettingsPage(User));
                    }
                    else
                    {
                        //Popup an error
                        Message = "An error has occured at the server. Please try again later.";
                        MessageColor = Brushes.Red;
                        PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                        PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                        PopupOpened = true;
                        
                    }
                }
                catch (Exception e)
                {
                    //Popup an error
                    Message = "An error has occured.";
                    MessageColor = Brushes.Red;
                    PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                    PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                    PopupOpened = true;
                    
                }

                IsBusy = false;
            }
        }

        #endregion
    }
}