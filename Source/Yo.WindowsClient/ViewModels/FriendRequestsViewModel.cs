using System;
using System.Threading.Tasks;
using Yo.WindowsClient.Views;
using Yo.WindowsClient.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Yo.Models.ViewModels;

namespace Yo.WindowsClient.ViewModels
{
    public class FriendRequestsViewModel : BaseViewModel
    {
        #region Private Fields
        
        private ObservableCollection<RequestUserViewModel> friendRequests;
        private UserViewModel user;
        private RequestUserViewModel selectedUser;

        #endregion

        #region Constructor

        public FriendRequestsViewModel(UserViewModel user)
        {
            this.user = user;

            GetRequestsTimer();
        }

        #endregion

        #region Public Properties

        public ObservableCollection<RequestUserViewModel> FriendRequests
        {
            get => friendRequests;
            set
            {
                if (friendRequests != value)
                {
                    friendRequests = value;
                    OnPropertyChanged();
                }
            }
        }

        public UserViewModel User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public RequestUserViewModel SelectedUser
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

        public ICommand AcceptCommand
        {
            get => new Command(async () => await AcceptRequest());
        }

        public ICommand RejectCommand
        {
            get => new Command(async () => await RejectRequest());
        }

        public ICommand BackCommand
        {
            get => new Command(() => Back());
        }
        #endregion

        #region Methods

        private async Task RejectRequest()
        {
            IsBusy = true;

            try
            {
                //Send a rejection request
                var response = await Yo.Api.Client.Models.FriendRequest.RejectRequestAsync(User.UserId, SelectedUser.UserId);

                if (response.Status.Equals("Success"))
                {
                    FriendRequests.Remove(SelectedUser);
                    Message = "Request has been rejected.";

                    if (FriendRequests.Count == 0)
                    {
                        IsBusy = false;
                        PagesSwitcher.SwitchToPage(new FriendsPage(User));
                    }
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

        private async Task AcceptRequest()
        {
            IsBusy = true;

            try
            {
                //Send an acceptance request
                var response = await Yo.Api.Client.Models.FriendRequest.AcceptRequestAsync(User.UserId, SelectedUser.UserId);

                if (response.Status.Equals("Success"))
                {
                    FriendRequests.Remove(SelectedUser);
                    Message = "Request has been accepted.";

                    if (FriendRequests.Count == 0)
                    {
                        IsBusy = false;
                        PagesSwitcher.SwitchToPage(new FriendsPage(User));
                    }
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

        private async void GetRequests()
        {
            IsBusy = true;

            try
            {
                var response = await Yo.Api.Client.Models.FriendRequest.GetPendingRequestsAsync(User.UserId);

                FriendRequests = new ObservableCollection<RequestUserViewModel>(response);
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

        private void Back()
        {
            PagesSwitcher.SwitchToPage(new FriendsPage(User));
        }


        private async void GetRequestsTimer()
        {
            while (true)
            {
                GetRequests();
                await Task.Delay(10000);
            }
        }
        #endregion

    }
}
