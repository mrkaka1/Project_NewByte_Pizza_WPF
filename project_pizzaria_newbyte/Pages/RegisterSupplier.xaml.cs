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
using System.Windows.Shapes;

namespace project_pizzaria_newbyte.Pages
{
    /// <summary>
    /// Lógica interna para RegisterSupplier.xaml
    /// </summary>
    public partial class RegisterSupplier : Window
    {
        public RegisterSupplier()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (
                   inputName.Text.Length > 0 &&
                   inputCnpj.Text.Length > 0 &&
                   inputEndereco.Text.Length > 0 &&
                   inputCep.Text.Length > 0
                )
                {
                    SupplierIDAO supplierIDAO = new SupplierIDAO();

                    SupplierModel supplier = new SupplierModel();

                    supplier.Name = inputName.Text;
                    supplier.CNPJ = inputCnpj.Text;
                    supplier.Endereco = inputEndereco.Text;
                    supplier.Cep = inputCep.Text;

                    supplierIDAO.Create(supplier);


                }

            }
            catch (Exception ex) { MessageBox.Show("ERROR:" + ex); }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ConsultSupplier consultSupplier = new ConsultSupplier();

            consultSupplier.ShowDialog();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            inputName.Text = "";
            inputCnpj.Text = "";

            inputEndereco.Text = "";
            inputCep.Text = "";
        }
    }
}
