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
            if (
                    nameInput.Text.Length > 0 &&
                    measureSelect.Text.Length > 0 &&
                    supplierSelect.Text.Length > 0
            )
            {
                double amount, price;

                if (double.TryParse(amountInput.Text, out amount) && double.TryParse(priceInput.Text, out price))
                {
                    ProductIDAO produtoCRUD = new ProductIDAO();

                    ProductModel produto = new ProductModel();

                    produto.Nome = nameInput.Text;
                    produto.Valor = price;
                    produto.Medida = measureSelect.Text;
                    produto.Quantidade = amount;

                    produtoCRUD.Create(produto);
                    
                    
                } else
                {
                    MessageBox.Show("Campos de quantidade e preço inválidos.");
                }
            }
            else
            {
                MessageBox.Show("Campos obrigatórios não preenchidos.");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}