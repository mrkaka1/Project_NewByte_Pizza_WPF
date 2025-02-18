using project_pizzaria_newbyte.Interface;
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
    /// Lógica interna para RegisterSupplier.xaml
    /// </summary>
    public partial class RegisterSupplier : Window
    {
        public RegisterSupplier()
        {
            InitializeComponent();
        }

        private void RegisterSuppliers(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (
                   inputName.Text.Length > 0 &&
                   inputCnpj.Text.Length > 0 &&
                   inputAddress.Text.Length > 0 &&
                   inputCep.Text.Length > 0
                )
                {
                    SupplierIDAO IDAO = new SupplierIDAO();
                    ValidateData check = new ValidateData();

                    if (check.CP(inputCnpj.Text, true))
                    {
                        SupplierModel supplier = new SupplierModel();
                        supplier.Nome = inputName.Text;
                        supplier.CNPJ = inputCnpj.Text;
                        supplier.Endereco = inputAddress.Text;
                        supplier.Cep = inputCep.Text;

                        IDAO.Create(supplier);
                    }

                }

            }
            catch (Exception ex) { MessageBox.Show("ERROR:" + ex); }
        }

        private void ClearInputs(object sender, MouseButtonEventArgs e)
        {
            inputName.Text = "";
            inputCnpj.Text = "";
            inputAddress.Text = "";
            inputCep.Text = "";
        }
    }
}
