using System;
using System.Windows;

namespace Medico
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to exit?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
            else
                System.Windows.Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            User_dayDate.Content = DateTime.Now.ToString("dddd , \n MMM dd yyyy");
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you would like to logout?", "", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            {
                var log = new LoginWindow();
                App.Current.MainWindow = log;
                this.Closing -= Window_Closing;
                this.Close();
                log.Show();
            }
            else
            {

            }
        }
    }
}
