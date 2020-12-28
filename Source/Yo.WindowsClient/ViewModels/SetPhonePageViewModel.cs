using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Yo.WindowsClient.Models;
using AKSoftware.Text;
using System.Windows.Input;
using Yo.WindowsClient.Views;
using Newtonsoft.Json;
using System.Windows.Media;
using Yo.Models.ViewModels;
using System.Windows.Controls.Primitives;

namespace Yo.WindowsClient.ViewModels
{
    public class SetPhonePageViewModel : BaseViewModel
    {
        #region Private Fields
        
        private UserViewModel user;
        private MessageWindow messageWindow;
        private List<Country> countries;
        private string phone;

        #endregion

        #region Contstructor

        public SetPhonePageViewModel(UserViewModel user)
        {
            this.User = user;

            var task = GetCountries();
        }

        #endregion

        #region Public Properties


        public UserViewModel User
        {
            get => user;
            set { user = value; OnPropertyChanged(); }
        }

        public string Phone
        {
            get => phone;
            set
            {
                if (!Validation.IsPhoneNumber(value))
                {
                    Message = "Phone is not Valid";
                }

                phone = value;
            }
        }
        
        public List<Country> Countries
        {
            get => countries;
            private set{countries = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public ICommand CancelCommand
        {
            get => new Command(() => Cancel());
        }

        public ICommand SetPhoneCommand
        {
            get => new Command(async () => await SetPhone());
        }
        #endregion

        #region Methods

        private async Task GetCountries()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    var result = await client.GetStringAsync("https://gist.githubusercontent.com/keeguon/2310008/raw/bdc2ce1c1e3f28f9cab5b4393c7549f38361be4e/countries.json");

                    Countries = JsonConvert.DeserializeObject<List<Country>>(result);
                }
            }
            catch (Exception e)
            {
                Countries.Add(new Country { Name = "No Countries" });
            }
            
        }

        private async Task SetPhone()
        {
            IsBusy = true;
            Message = "";
            var tempPhone = User.Phone;

            if (!Validation.IsPhoneNumber(phone))
            {
                Message = "Phone is not valid.";
            }
            else
            {
                User.Phone = phone;

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
                        Message = "Phone has been updated.";
                        IsBusy = false;
                        PagesSwitcher.SwitchToPage(new SettingsPage(User));

                    }
                    else
                    {
                        User.Phone = tempPhone;

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
