using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using Yo.Models.ViewModels;
using Yo.WindowsClient.ViewModels;

namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        private readonly UserViewModel user;

        public SettingsPage(UserViewModel user)
        {
            InitializeComponent();
            this.user = user;
            this.SizeChanged += OnResizeWindow;
            this.mainBorder.MouseDown += AnimateMainOutActionsIn;
            this.btnClose.Click += AnimateMainInActionsOut;
            this.DataContext = new SettingsPageViewModel(this.user);
        }

        #region Helper Functions

        private void OnResizeWindow(object sender, RoutedEventArgs args)
        {
            this.mainBorder.Width = this.WindowWidth;
            this.actionsBorder.Width = this.WindowWidth;

            this.actionsBorder.Margin = new Thickness(this.WindowWidth, 0, 0, 0);

        }

        #endregion

        #region Animation Functions

        private void AnimateMainOutActionsIn(object sender, RoutedEventArgs args)
        {
            //Create the storyBoard
            Storyboard sb = new Storyboard();

            //Create the animation for both the components
            ThicknessAnimation itemAnimation = new ThicknessAnimation()
            {
                To = new Thickness((-this.mainBorder.Width * 1.6), 0, 0, 0),
                Duration = new Duration(TimeSpan.FromMilliseconds(2500)),
                DecelerationRatio = 0.9f
            };

            ThicknessAnimation menuAnimation = new ThicknessAnimation()
            {
                To = new Thickness(0, 0, 0, 0),
                Duration = new Duration(TimeSpan.FromMilliseconds(2500)),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(itemAnimation, new PropertyPath("Margin"));
            sb.Children.Add(itemAnimation);
            Storyboard.SetTargetName(itemAnimation, "mainBorder");

            Storyboard.SetTargetProperty(menuAnimation, new PropertyPath("Margin"));
            sb.Children.Add(menuAnimation);
            Storyboard.SetTargetName(menuAnimation, "actionsBorder");

            sb.Begin(this);

        }

        private void AnimateMainInActionsOut(object sender, RoutedEventArgs args)
        {
            Storyboard sb = new Storyboard();

            ThicknessAnimation itemAnimation = new ThicknessAnimation()
            {
                To = new Thickness(0, 0, 0, 0),
                Duration = new Duration(TimeSpan.FromMilliseconds(2500)),
                DecelerationRatio = 0.9f
            };

            ThicknessAnimation menuAnimation = new ThicknessAnimation()
            {
                To = new Thickness(this.WindowWidth, 0, 0, 0),
                Duration = new Duration(TimeSpan.FromMilliseconds(2500)),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(itemAnimation, new PropertyPath("Margin"));
            sb.Children.Add(itemAnimation);
            Storyboard.SetTargetName(itemAnimation, "mainBorder");

            Storyboard.SetTargetProperty(menuAnimation, new PropertyPath("Margin"));
            sb.Children.Add(menuAnimation);
            Storyboard.SetTargetName(menuAnimation, "actionsBorder");

            sb.Begin(this);
        }

        #endregion
    }
}
