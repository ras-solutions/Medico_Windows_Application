﻿using System.Media;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Medico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public static class ValidatorExtensions
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
    }

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }


        bool em;
        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            em = ValidatorExtensions.IsValidEmailAddress(email.Text);
        }

        private void email_GotFocus(object sender, RoutedEventArgs e)
        {
            email.ClearValue(TextBox.BorderBrushProperty);
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


            if (role.Text == "")
            {
                MessageBox.Show("Please select a role", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (email.Text == "" || email.Text == "Email")
            {
                MessageBox.Show("Email field empty, Please Check", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!em)
            {
                email.BorderBrush = System.Windows.Media.Brushes.Red;
                SystemSounds.Beep.Play();
                MessageBox.Show("Invalid Email, Please check", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (em && role.Text == "Reception")
            {
                Reception rec = new Reception();
                App.Current.MainWindow = rec;
                rec.Show();
                this.Close();
            }
            else if (em && role.Text == "User")
            {
                User usr = new User();
                App.Current.MainWindow = usr;
                usr.Show();
                this.Close();
            }
            else if (em && role.Text == "Doctor")
            {
                Doctor dct = new Doctor();
                App.Current.MainWindow = dct;
                dct.Show();
                this.Close();
            }
            else if (em && role.Text == "Pharmacy")
            {
                Pharmacy ph = new Pharmacy();
                App.Current.MainWindow = ph;
                ph.Show();
                this.Close();
            }

        }

    }
}
