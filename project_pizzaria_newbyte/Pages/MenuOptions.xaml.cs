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
    /// Lógica interna para MenuOptions.xaml
    /// </summary>
    public partial class MenuOptions : Window
    {
        public MenuOptions()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationEmployee registrationEmployee = new RegistrationEmployee();
            registrationEmployee.Show();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterSupplier registrationSupplier = new RegisterSupplier();
            registrationSupplier.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ConsultSupplier supplier = new ConsultSupplier();
            supplier.Show();
        }

        private void consFuncionarioBtn_Click(object sender, RoutedEventArgs e)
        {
            ConsultEmployees consultEmployees = new ConsultEmployees();
            consultEmployees.Show();
        }
    }
}
