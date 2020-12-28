using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Yo.WindowsClient.Models;
using System.Collections.ObjectModel;
using Yo.Models.ViewModels;
using Yo.WindowsClient.Views;
using System.Windows.Media;
using System.Windows.Controls.Primitives;

namespace Yo.WindowsClient.ViewModels
{
    public class BlockedFriendsPageViewModel : BaseViewModel
    {
        #region Private Fields
        
        private UserViewModel user;
        private BlockedFriendViewModel selectedUser;
        private ObservableCollection<BlockedFriendViewModel> blockedFriends;
        
        #endregion

        #region Constructor

        public BlockedFriendsPageViewModel(UserViewModel user)
        {
            this.User = user;

            GetBlockedFriendsTimer();
        }

        #endregion

        #region Public Properties

        public ObservableCollection<BlockedFriendViewModel> BlockedFriends
        {
            get { return blockedFriends; }
            set { blockedFriends = value; OnPropertyChanged(); }
        }

        public UserViewModel User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public BlockedFriendViewModel SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand UnblockCommand
        {
            get => new Command(async () => await UnblockFriend());
        }

        public ICommand BackCommand
        {
            get => new Command(() => Back());
        }

        #endregion

        #region Methods

        private async Task UnblockFriend()
        {
            IsBusy = true;

            try
            {
                var response = await Yo.Api.Client.Models.FriendRelation.UnblockFriendAsync(User.UserId, SelectedUser.UserId);

                if (response.Status.Equals("Success"))
                {
                    BlockedFriends.Remove(SelectedUser);
                    
                    if (BlockedFriends.Count == 0)
                    {
                        PagesSwitcher.SwitchToPage(new SettingsPage(User));
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

        private async Task GetBlockedFriends()
        {
            IsBusy = true;

            try
            {
                //Get all blocked friends
                var blockedFriends = await Yo.Api.Client.Models.FriendRelation.GetBlockedFriendsAsync(User.UserId);

                this.BlockedFriends = new ObservableCollection<BlockedFriendViewModel>(blockedFriends);
            }
            catch (Exception e)
            {
                //Popup an error
                Message = "An error has occured while loading your blocekd friends.";
                MessageColor = Brushes.Red;
                PopupWidth = WindowBoundaryProvider.WindowWidth / 4;
                PopupHeight = WindowBoundaryProvider.WindowHeight / 4;
                PopupOpened = true;
                
            }

            IsBusy = false;
        }

        private void Back()
        {
            PagesSwitcher.SwitchToPage(new SettingsPage(User));
        }
        
        private async void GetBlockedFriendsTimer()
        {
            while (true)
            {
                GetBlockedFriends();
                await Task.Delay(10000);
            }
        }

        #endregion
        
    }
}
