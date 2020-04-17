using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Medico
{
    /// <summary>
    /// Interaction logic for Reception.xaml
    /// </summary>
    public partial class Reception : Window
    {
        BackgroundWorker worker;
        public Reception()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        bool f=false;

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (!worker.CancellationPending)
            {
                worker.ReportProgress(0);
                System.Threading.Thread.Sleep(500);
            }
        }
       
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var r = new SolidColorBrush(Colors.Red);
            if (f == false)
            {
                this.Background = new SolidColorBrush(Colors.White);
                f = true;
            }
            else
            {
                this.Background = new SolidColorBrush(Colors.Red);
                f = false;
            }
        }
        private int clickCounter = 0;
        private void SOS_Click(object sender, RoutedEventArgs e)
        {
            
            if (clickCounter >= 1)
            {
                SOS1.Visibility = Visibility.Hidden;
                SOS2.Visibility = Visibility.Hidden;
                worker.CancelAsync();
                this.Background = new SolidColorBrush(Colors.White);
                clickCounter = 0;
            }
            else
            {
                SOS1.Visibility = Visibility.Visible;
                SOS2.Visibility = Visibility.Visible;
                worker.RunWorkerAsync();
                System.Threading.Thread.Sleep(500);
                clickCounter += 1;
            }
           

        }

        private void SOS2_MouseEnter(object sender, MouseEventArgs e)
        {
            SOS2.Foreground = new SolidColorBrush(Colors.Green);
        }

        private void SOS2_MouseLeave(object sender, MouseEventArgs e)
        {
            SOS2.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF001FFF"));
        }

        private void SOS2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var res = new SOSResult();
            res.Show();
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
