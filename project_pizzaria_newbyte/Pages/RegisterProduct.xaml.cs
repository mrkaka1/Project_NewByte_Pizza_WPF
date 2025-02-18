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
    /// Lógica interna para RegisterProduct.xaml
    /// </summary>
    public partial class RegisterProduct : Window
    {
        public RegisterProduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (
                        inputName.Text.Length > 0 &&
                        selectMeasure.Text.Length > 0 &&
                        inputPrice.Text.Length > 0
                )
                {
                    double amount = Convert.ToDouble(inputAmount.Text), price = Convert.ToDouble(inputPrice.Text.Replace(",", "."));

                    ProductIDAO produtoCRUD = new ProductIDAO();

                    ProductModel produto = new ProductModel();

                    produto.Nome = inputName.Text;
                    produto.Valor = price;
                    produto.Medida = selectMeasure.Text;
                    produto.Quantidade = amount;

                    produtoCRUD.Create(produto);
                }
                else
                {
                    MessageBox.Show("Algumas informações estão inseridas incorretamente.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            inputAmount.Text = "";
            inputName.Text = "";
            inputPrice.Text = "";
        }
    }
    
}