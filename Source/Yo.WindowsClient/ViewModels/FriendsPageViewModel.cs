using System;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Yo.WindowsClient.Models;
using Yo.WindowsClient.Views;
using System.Windows.Media;
using Yo.Models.ViewModels;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Controls.Primitives;

namespace Yo.WindowsClient.ViewModels
{
    public class FriendsPageViewModel : BaseViewModel
    {
        #region Private Fields

        private UserViewModel user;
        private ObservableCollection<FriendUserViewModel> friends;
        private FriendUserViewModel selectedUser;
        private string addingUsername = string.Empty;

        #endregion

        #region Constructor

        public FriendsPageViewModel(UserViewModel user)
        {
            this.User = user;

            GetFriendsTimer();
            CheckYos();
        }

        #endregion

        #region Public Properties

        public ObservableCollection<FriendUserViewModel> Friends
        {
            get => friends;
            set
            {
                if (friends != value)
                {
                    friends = value;
                    OnPropertyChanged();
                }
            }
        }

        public UserViewModel User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public FriendUserViewModel SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (value != selectedUser)
                {
                    selectedUser = value;
                    OnPropertyChanged();
                }
            }
        }

        public string AddingUsername
        {
            get { return addingUsername; }
            set { addingUsername = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands

        public ICommand OpenSettingsCommand
        {
            get => new Command(() => OpenSettingsPage());
        }

        public ICommand OpenFriendRequestsCommand
        {
            get => new Command(() => OpenFriendRequestsPage());
        }

        public ICommand AddUsernameCommand
        {
            get => new Command(async () => await AddUsername());
        }

        public ICommand DeleteFriendCommand
        {
            get => new Command(async () => await DeleteFriend());
        }

        public ICommand BlockFriendCommand
        {
            get => new Command(async () => await BlockFriend());
        }

        public ICommand SendYoCommand
        {
            get => new Command(async () => await SendYo());
        }

        #endregion

        #region Methods

        private async void GetFriends()
        {
            IsBusy = true;
            try
            {
                var response = await Yo.Api.Client.Models.FriendRelation.GetFriendsAsync(User.UserId);

                Friends = new ObservableCollection<FriendUserViewModel>(response);

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

        private async Task SendYo()
        {
            IsBusy = true;

            try
            {
                var response = await Yo.Api.Client.Models.YoType.SendYoAsync(User.UserId, SelectedUser.UserId, false);

                if (response.Status == "Success")
                {
                    Message = "Yo has been sent";
                    MessageColor = Brushes.Green;
                    PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                    PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                    PopupOpened = true;

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

        private async Task AddUsername()
        {
            IsBusy = true;
            try
            {
                //Get the user with the entered usename
                var userByUsername = await Yo.Api.Client.Models.User.GetUserByUsernameAsync(addingUsername);

                //Check if the user exists
                if (userByUsername == null)
                {
                    Message = $"Username does not exist";
                    MessageColor = Brushes.Red;
                    PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                    PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                    PopupOpened = true;

                }
                else
                {
                    var response = await Yo.Api.Client.Models.FriendRequest.SendRequestAsync(User.UserId, userByUsername.UserId);

                    if (response.Status.Equals("Success"))
                    {
                        //Popup a success message
                        Message = "Request has been sent.";
                        MessageColor = Brushes.Green;
                        PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                        PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                        PopupOpened = true;

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

        private async Task DeleteFriend()
        {
            IsBusy = true;

            try
            {
                string deletedUserName = SelectedUser.Username;

                var response = await Yo.Api.Client.Models.FriendRelation.UnFriendAsync(User.UserId, SelectedUser.UserId);

                if (response.Status.Equals("Success"))
                {
                    Friends.Remove(SelectedUser);
                    Message = $"{deletedUserName} has been deleted";
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
            catch (Exception ex)
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

        private async Task BlockFriend()
        {
            IsBusy = true;

            try
            {
                string blockedUserName = SelectedUser.Username;
                var response = await Yo.Api.Client.Models.FriendRelation.BlockFriendAsync(User.UserId, SelectedUser.UserId);


                if (response.Status.Equals("Success"))
                {
                    Friends.Remove(SelectedUser);
                    Message = $"{blockedUserName} has been blocked";
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
            catch (Exception ex)
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

        private async Task CheckYos()
        {
            try
            {
                while (true)
                {
                    var response = await Yo.Api.Client.Models.YoType.GetYosAsync(User.UserId);

                    if (response.Status.Equals("Success"))
                    {
                        var groupedYos = response.Yos.GroupBy(y => y.FromUser.Username);

                        foreach (var yo in groupedYos)
                        {
                            NotifyIcon icon = new NotifyIcon();
                            icon.Visible = true;
                            icon.Tag = yo.Key;
                            icon.Text = yo.Count() > 1 ? $"Yos from {yo.Key}." : $"Yo from {yo.Key}";
                            icon.Icon = new System.Drawing.Icon(@"icon.ico");
                            icon.BalloonTipIcon = ToolTipIcon.Info;
                            icon.BalloonTipText = yo.Count() > 1 ? $"{yo.Count()} yos received from {yo.Key}." : $"Yo received from {yo.Key}";
                            icon.BalloonTipTitle = "Hey Yo";

                            //var menu = new System.Windows.Forms.ContextMenu();
                            //menu.MenuItems.Add("Yo Back");
                            //menu.MenuItems[0].Click += (object sender, EventArgs e) =>
                            //{
                            //    System.Windows.MessageBox.Show(e.ToString());

                            //};

                            //icon.ContextMenu = menu;

                            icon.ShowBalloonTip(5000);
                        }

                        var response1 = await Yo.Api.Client.Models.YoType.MakeYosRecieved(User.UserId);

                        if (response1.Status.Equals("Success"))
                        {
                            Message = "Yos have been made received.";
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
                    else
                    {
                        //Popup an error
                        Message = response.Message;
                        MessageColor = Brushes.Red;
                        PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                        PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                        PopupOpened = true;

                    }
                    await Task.Delay(5000);
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

            IsBusy = false;
        }

        private void OpenSettingsPage()
        {
            PagesSwitcher.SwitchToPage(new SettingsPage(User));
        }

        private void OpenFriendRequestsPage()
        {
            PagesSwitcher.SwitchToPage(new FriendRequestsPage(User));
        }

        private async void GetFriendsTimer()
        {
            while (true)
            {
                GetFriends();
                await Task.Delay(10000);
            }
        }
        
        #endregion
    }
}
