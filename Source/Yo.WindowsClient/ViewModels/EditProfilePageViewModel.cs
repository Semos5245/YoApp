using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Yo.WindowsClient.Models;
using Yo.WindowsClient.Views;
using System.Windows.Forms;
using Yo.Models.ViewModels;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Yo.WindowsClient.ViewModels
{
    public class EditProfilePageViewModel : BaseViewModel
    {
        #region Private Fields

        private UserViewModel user;
        private string fullName = string.Empty;
        private string imagePath = string.Empty;

        #endregion

        #region Constructor

        public EditProfilePageViewModel(UserViewModel user)
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

        public string FullName
        {
            get => User.FullName;
            set { fullName = value; OnPropertyChanged(); }
        }

        public string ImagePath
        {
            get => User.ImagePath;
            set { imagePath = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public ICommand SaveCommand
        {
            get => new Command(async () => await SaveData());
        }

        public ICommand CancelCommand
        {
            get => new Command(() => Cancel());
        }

        public ICommand OpenFileDialogCommand
        {
            get => new Command(async () => await SaveImage());
        }
        #endregion

        #region Methods

        private async Task SaveData()
        {
            IsBusy = true;

            try
            {
                var model = new EditProfileInfoViewModel
                {
                    UserId = User.UserId,
                    Email = User.Email,
                    FullName = User.FullName,
                    Phone = User.Phone
                };

                var response = await Yo.Api.Client.Models.User.EditProfileAsync(model);

                if (response.Status.Equals("Success"))
                {
                    IsBusy = false;
                    User.FullName = fullName;
                    Message = "Profile has been updated.";
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

        private async Task SaveImage()
        {
            using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
            {
                ofd.Filter = "All Images|*.jpg;*.png;*.bmp";
                ofd.FileName = string.Empty;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var response = await Yo.Api.Client.Models.User.UploadProfilePictureAsync(User.UserId, ofd.FileName);

                        if (response.Status.Equals("Success"))
                        {
                            Message = "Image has been updated";
                            User.ImagePath = response.NewImagePath;
                            OnPropertyChanged("ImagePath");
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
                    catch (Exception ex)
                    {
                        //Popup an error
                        Message = "An error has occured.";
                        MessageColor = Brushes.Red;
                        PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                        PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                        PopupOpened = true;
                        
                    }
                }

                IsBusy = false;
            }
        }

        private void Cancel()
        {
            PagesSwitcher.SwitchToPage(new SettingsPage(User));
        }

        #endregion
    }
}
