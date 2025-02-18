using project_pizzaria_newbyte.Model;
using project_pizzaria_newbyte.Utils;
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
using System.Windows.Shapes;

namespace project_pizzaria_newbyte.Pages
{
    /// <summary>
    /// Lógica interna para RegistrationEmployee.xaml
    /// </summary>
    public partial class RegistrationEmployee : Window
    {
        public RegistrationEmployee()
        {
            InitializeComponent();
        }

        private void RegisterEmployee(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (
                   inputName.Text.Length > 0 &&
                   inputEmail.Text.Length > 0 &&
                   inputPhone.Text.Length > 0 &&
                   inputCpf.Text.Length > 0 &&
                   inputAccess.Text.Length > 0 &&
                   inputOffice.Text.Length > 0 &&
                   inputPassword.Text.Length > 0
                )
                {
                    EmployeeIDAO IDAO = new EmployeeIDAO();
                    ValidateData check = new ValidateData();

                    if (check.CP(inputCpf.Text, false) && check.Email(inputEmail.Text) && check.Phone(inputPhone.Text))
                    {
                        EmployeeModel employee = new EmployeeModel();

                        employee.Nome = inputName.Text;
                        employee.Email = inputEmail.Text;
                        employee.Telefone = inputPhone.Text;
                        employee.Cpf = inputCpf.Text;
                        employee.Acesso = inputAccess.Text;
                        employee.Cargo = inputOffice.Text;
                        employee.Senha = inputPassword.Text;

                        IDAO.Create(employee);
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show("Error:" + ex); }
        }

        private void ClearInputs(object sender, MouseButtonEventArgs e)
        {
            inputAccess.Text = "";
            inputCpf.Text = "";
            inputEmail.Text = "";
            inputName.Text = "";
            inputOffice.Text = "";
            inputPassword.Text = "";
            inputPhone.Text = "";
        }
    }
}
