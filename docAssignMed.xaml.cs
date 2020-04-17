
using System.Data;
using System.Windows;

namespace Medico

{

    /// <summary>

    /// Interaction logic for MainWindow.xaml

    /// </summary>

    public partial class docAssignMed : Window


    {

        public docAssignMed()

        {

            InitializeComponent();

        }

        DataTable dt;

        private void Window_Loaded(object sender, RoutedEventArgs e)

        {

            dt = new DataTable("emp");

            DataColumn dc1 = new DataColumn("Name", typeof(string));

            DataColumn dc2 = new DataColumn("Varient", typeof(string));

            DataColumn dc3 = new DataColumn("Quantity", typeof(string));

            DataColumn dc4 = new DataColumn("Frequency", typeof(string));

            dt.Columns.Add(dc1);

            dt.Columns.Add(dc2);

            dt.Columns.Add(dc3);

            dt.Columns.Add(dc4);

            dataGrid1.ItemsSource = dt.DefaultView;

        }

        DataRow dr;

        private void button1_Click(object sender, RoutedEventArgs e)

        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Empty value, Please check", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = textBox1.Text;
                dr[1] = textBox2.Text;
                dr[2] = textBox3.Text;
                dr[3] = textBox4.Text;
                dt.Rows.Add(dr);
                dataGrid1.ItemsSource = dt.DefaultView;
                textBox1.Focus();

            }

        }



        private void button2_Click(object sender, RoutedEventArgs e)

        {

            textBox1.Clear();

            textBox2.Clear();

            textBox3.Clear();

            textBox4.Clear();



        }



        private void button3_Click(object sender, RoutedEventArgs e)

        {



            dataGrid1.ItemsSource = dt.DefaultView;

            if (dt.Rows.Count == 1)
            {
                dt.Rows.Remove(dr);
                textBox1.Focus();
            }
            else if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dr);
                dr = dt.Rows[dt.Rows.Count - 1];
                textBox1.Focus();
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Prescription has been saved successfully", "", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }

}