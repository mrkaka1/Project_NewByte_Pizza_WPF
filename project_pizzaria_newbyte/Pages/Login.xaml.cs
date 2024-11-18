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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project_pizzaria_newbyte.Pages
{
    /// <summary>
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            framaPage.Source = new Uri("./SignUp.xaml",  UriKind.Relative);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string email = inputEmail.Text;
            string password = inputPassword.Text;

            if (AuthenticateUser(email, password))
            {
                MenuOptions menuOptions = new MenuOptions();
                menuOptions.ShowDialog();
            }
            else
            {
                MessageBox.Show("E-mail ou senha incorretos.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool AuthenticateUser(string email, string password)
        {
            var connection = new DataBase.Connection();
            try
            {
                connection.Connect();
                var query = connection.Query();

                query.CommandText = "SELECT COUNT(*) FROM Cliente WHERE email_cli = @Email AND senha_cli = @Password";
                query.Parameters.AddWithValue("@Email", email);
                query.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(query.ExecuteScalar());

                return count > 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao autenticar: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        private void framaPage_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
