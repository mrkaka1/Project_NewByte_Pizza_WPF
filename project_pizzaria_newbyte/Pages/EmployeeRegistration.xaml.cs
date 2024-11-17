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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace project_pizzaria_newbyte.Pages
{
    /// <summary>
    /// Interação lógica para EmployeeRegistration.xam
    /// </summary>
    public partial class EmployeeRegistration : Page
    {
        public EmployeeRegistration()
        {
            InitializeComponent();
        }
           

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try {
                if (
                   inputName.Text.Length > 0 &&
                   inputEmail.Text.Length > 0 &&
                   inputAcesso.Text.Length > 0 &&
                   inputCargo.Text.Length > 0 &&
                   inputSenha.Text.Length > 0 &&
                   inputRepSenha.Text.Length > 0
                )
                {
                    EmployeeIDAO employeeIDAO = new EmployeeIDAO();

                    EmployeeModel employee = new EmployeeModel();

                    employee.Nome = inputName.Text;
                    employee.Email = inputEmail.Text;
                    employee.Acesso = inputAcesso.Text;
                    employee.Cargo = inputCargo.Text;
                    employee.Senha = inputSenha.Text;
                    employee.Repetir_Senha = inputRepSenha.Text;

                    employeeIDAO.Create(employee);

                }

            } catch (Exception ex) { MessageBox.Show("ERROR:"+ ex); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConsultEmployees consultEmployees = new ConsultEmployees();
           
            consultEmployees.ShowDialog();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            inputName.Text = "";
            inputEmail.Text = "";
            inputAcesso.Text = "";
            inputCargo.Text = "";
            inputSenha.Text = "";
            inputRepSenha.Text = "";
        }
    }
}

