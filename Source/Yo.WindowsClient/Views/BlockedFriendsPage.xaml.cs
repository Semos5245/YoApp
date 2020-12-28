using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Yo.Models.ViewModels;
using Yo.WindowsClient.ViewModels;

namespace Yo.WindowsClient.Views
{
    /// <summary>
    /// Interaction logic for BlockedFriendsPage.xaml
    /// </summary>
    public partial class BlockedFriendsPage : Page
    {
        private UserViewModel user;
        Random random;
        private List<SolidColorBrush> colors = new List<SolidColorBrush>
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
            new SolidColorBrush(Colors.Pink),
            new SolidColorBrush(Colors.YellowGreen)
        };

        public BlockedFriendsPage(UserViewModel user)
        {
            InitializeComponent();
            this.user = user;
            this.random = new Random(DateTime.Now.Millisecond);
            this.lstBlockedFriends.Loaded += GenerateColors;
            this.DataContext = new BlockedFriendsPageViewModel(user);
        }

        private void GenerateColors(object sender, RoutedEventArgs e)
        {
            //foreach (ListViewItem item in lstBlockedFriends.Items)
            //{
            //    item.Background = this.colors[random.Next(0, colors.Count)];
            //}
        }
    }
}
