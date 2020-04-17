using System.Windows;

namespace Medico
{
    /// <summary>
    /// Interaction logic for Pharmacy.xaml
    /// </summary>
    public partial class Pharmacy : Window
    {
        public Pharmacy()
        {
            InitializeComponent();
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
    }
}
