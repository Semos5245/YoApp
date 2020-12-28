using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Yo.Models.ViewModels;
using Yo.WindowsClient.ViewModels;

namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for FriendsPage.xaml
    /// </summary>
    public partial class FriendsPage : Page
    {
        private readonly UserViewModel user;

        List<SolidColorBrush> colors = new List<SolidColorBrush>
        {
            new SolidColorBrush(Colors.Red),
            new SolidColorBrush(Colors.Blue),
            new SolidColorBrush(Colors.Black),
            new SolidColorBrush(Colors.Yellow),
            new SolidColorBrush(Colors.Green),
            new SolidColorBrush(Colors.Gray),
            new SolidColorBrush(Colors.Brown),
            new SolidColorBrush(Colors.Cyan),
            new SolidColorBrush(Colors.Orange),
            new SolidColorBrush(Colors.Purple),
            new SolidColorBrush(Colors.LightSeaGreen),
            new SolidColorBrush(Colors.Violet)
        };

        Random random = new Random(DateTime.Now.Millisecond);

        public FriendsPage(UserViewModel user)
        {
            InitializeComponent();
            this.user = user;
            this.SizeChanged += OnResize;
            this.btnAdd.Click += AnimateMainOutAddIn;
            this.addBorder.LostFocus += AnimateMainInAddOut;
            this.DataContext = new FriendsPageViewModel(this.user);
        }

        #region Helper Functions

        private void OnResize(object sender, RoutedEventArgs args)
        {
            this.mainBorder.Width = this.WindowWidth;
            this.addBorder.Width = this.WindowWidth;

            this.addBorder.Margin = new Thickness(this.WindowWidth, 0, 0, 0);
        }

        #endregion

        #region Animation Functions

        private void AnimateMainOutAddIn(object sender, RoutedEventArgs args)
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
            Storyboard.SetTargetName(menuAnimation, "addBorder");

            sb.Begin(this);

        }

        private void AnimateMainInAddOut(object sender, RoutedEventArgs args)
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
            Storyboard.SetTargetName(menuAnimation, "addBorder");

            sb.Begin(this);
        }

        #endregion
    }
}
