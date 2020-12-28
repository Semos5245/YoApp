using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Yo.WindowsClient
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(string message, Brush foregroundColor)
        {
            InitializeComponent();
            this.btnOk.Click += OkClicked;
            this.txtMessage.Text = message;
            this.txtMessage.Foreground = foregroundColor;
        }

        private void OkClicked(object sender, RoutedEventArgs args)
        {
            this.Close();
        }
    }
}
