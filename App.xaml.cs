using System.Threading.Tasks;
using System.Windows;

namespace Medico
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //initialize the splash screen and set it as the application main window
            SplashScreenWindow splashScreen = new SplashScreenWindow();
            this.MainWindow = splashScreen;
            splashScreen.Show();

            //loading on seperate thread
            Task.Factory.StartNew(() =>
            {
                //simulate some work being done for now
                System.Threading.Thread.Sleep(1700);

                //since we're not on the UI thread
                //once we're done we need to use the Dispatcher
                //to create and show the main window
                this.Dispatcher.Invoke(() =>
                {
                    //initialize the main window, set it as the application main window
                    //and close the splash screen
                    var loginWindow = new LoginWindow();
                    this.MainWindow = loginWindow;
                    //loginWindow.Opacity = 0;
                    loginWindow.Show();
                    splashScreen.Close();
                });
            });
        }

    }
}
