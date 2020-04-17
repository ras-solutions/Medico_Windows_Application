using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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





        #region ScaleValue Depdency Property
        public static readonly DependencyProperty ScaleValueProperty = DependencyProperty.Register("ScaleValue", typeof(double), typeof(MainWindow), new UIPropertyMetadata(1.0, new PropertyChangedCallback(OnScaleValueChanged), new CoerceValueCallback(OnCoerceScaleValue)));

        private static object OnCoerceScaleValue(DependencyObject o, object value)
        {
            Reception mainWindow = o as Reception;
            if (mainWindow != null)
                return mainWindow.OnCoerceScaleValue((double)value);
            else
                return value;
        }

        private static void OnScaleValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Reception mainWindow = o as Reception;
            if (mainWindow != null)
                mainWindow.OnScaleValueChanged((double)e.OldValue, (double)e.NewValue);
        }

        protected virtual double OnCoerceScaleValue(double value)
        {
            if (double.IsNaN(value))
                return 1.0f;

            value = Math.Max(0.1, value);
            return value;
        }

        protected virtual void OnScaleValueChanged(double oldValue, double newValue)
        {

        }

        public double ScaleValue
        {
            get
            {
                return (double)GetValue(ScaleValueProperty);
            }
            set
            {
                SetValue(ScaleValueProperty, value);
            }
        }
        #endregion

        private void MainGrid_SizeChanged(object sender, EventArgs e)
        {
            CalculateScale();
        }

        private void CalculateScale()
        {
            double yScale = ActualHeight / 250f;
            double xScale = ActualWidth / 200f;
            double value = Math.Min(xScale, yScale);
            ScaleValue = (double)OnCoerceScaleValue(Rec, value);
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
        bool f = false;

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
