using project_pizzaria_newbyte.Model;
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

namespace project_pizzaria_newbyte.Pages
{
    /// <summary>
    /// Interação lógica para SignUp.xam
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (
                   inputName.Text.Length > 0 &&
                   inputEmail.Text.Length > 0 &&
                   inputCpf.Text.Length > 0 &&
                   inputPassWord.Text.Length > 0
                )
                {
                    ClientIDAO userIDAO = new ClientIDAO();

                    ClientModel user = new ClientModel();

                    user.Name = inputName.Text;
                    user.Email = inputEmail.Text;
                    user.Cpf = inputCpf.Text;
                    user.Password = inputPassWord.Text;
                    user.Phone = inputPhone.Text;

                    userIDAO.Create(user);

                }
                else MessageBox.Show("Algumas credenciais podem estar incorretas.");

            }
            catch (Exception ex) { MessageBox.Show("ERROR:" + ex); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            formSignUp.Visibility = Visibility.Collapsed;
        }

    }
}
