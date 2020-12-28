using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Yo.WindowsClient.Models;

namespace Yo.WindowsClient.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Private Fields
        
        protected SolidColorBrush messageColor;
        protected bool popupOpened = false;
        protected bool isBusy = false;
        protected string message = string.Empty;
        protected double popupWidth;
        protected double popupHeight;

        #endregion

        #region Constructor

        public BaseViewModel()
        {
        }

        #endregion

        #region Public Properties

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public bool PopupOpened
        {
            get => popupOpened;
            set { popupOpened = value; OnPropertyChanged(); }
        }

        public double PopupWidth
        {
            get => popupWidth;
            set { popupWidth = value; OnPropertyChanged(); }
        }

        public double PopupHeight
        {
            get => popupHeight;
            set { popupHeight = value; OnPropertyChanged(); }
        }

        public SolidColorBrush MessageColor
        {
            get => messageColor;
            set { messageColor = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public ICommand ClosePopupCommand
        {
            get => new Command(() => this.PopupOpened = false);
        }

        #endregion

        #region Property Changed Notification

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}
