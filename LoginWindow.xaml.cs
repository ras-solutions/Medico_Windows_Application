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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Medico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void email_GotFocus(object sender, RoutedEventArgs e)
        {
            if (email.Text == "Email")
            {
                email.Text = "";
            }
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (email.Text == "")
            {
                email.Text = "Email";    
            }
        }

        private void passwd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwd.Text == "Password")
            {
                passwd.Text = "";
            }
        }

        private void passwd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwd.Text == "")
            {
                passwd.Text = "Password";
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
