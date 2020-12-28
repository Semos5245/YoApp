using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Navigation;
using Yo.WindowsClient.Models;
using Yo.WindowsClient.Views;

namespace Yo.WindowsClient.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Private Fields
        
        #endregion

        #region Constructor

        public MainPageViewModel() { }

        #endregion

        #region Commands

        public ICommand OpenSignupPageCommand
        {
            get { return new Command(() => OpenSignupPage()); }
        }

        public ICommand OpenLoginPageCommand
        {
            get { return new Command(() => OpenLoginPage()); }
        }
        
        #endregion

        #region Methods

        private void OpenSignupPage()
        {
            PagesSwitcher.SwitchToPage(new SignupPage());
        }

        private void OpenLoginPage()
        {
            PagesSwitcher.SwitchToPage(new LoginPage());
        }

        #endregion
    }
}
