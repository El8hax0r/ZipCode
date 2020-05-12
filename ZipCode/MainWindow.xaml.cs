using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
namespace ZipCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    //Create a new WPF Project with a TextBox that only accepts:
    //US Zip Codes ##### or #####-####
    //Canadian Postal Codes: A#B#C#

    //The window contains a Submit button that is only enabled when a valid zip code or postal code is entered.
    //So for example, a user could enter 98122 or 98012-4444 or T1R2X4 and the Submit button would be enabled.
    //The Submit button does not need to perform any action.
    //Hint: Keep things simple and use a TextBox and an event on the TextBox.
    //Hint: Don't use User Controls and don't use XAML binding. It's a lot of work.
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string usZipCode = @"^\d{5}(?:[-\s]\d{4})?$";
        string caZipCode = @"^([ABCDEFGHIJKLMNOPQRSTUVWXYZ]\d[ABCDEFGHIJKLMNOPQRSTUVWXYZ])\ {0,1}(\d[ABCDEFGHIJKLMNOPQRSTUVWXYZ]\d)$";

        private bool IsValidPostalCode(string PostalCode)
        {
            var isValidPostalCode = false;
            if ((Regex.Match(PostalCode,usZipCode).Success) || (Regex.Match(PostalCode,caZipCode).Success))
            {
                isValidPostalCode = true;
            }
            return isValidPostalCode;
        }

        private void uxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            uxSubmit.IsEnabled = false;
            if (IsValidPostalCode(uxNumber.Text))
            {
                uxSubmit.IsEnabled = true;
            }
        }
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{uxNumber.Text} is a valid zip code.");
        }
    }
}
