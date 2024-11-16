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
using project_pizzaria_newbyte.Model;
using project_pizzaria_newbyte.DataBase;
using Google.Protobuf.WellKnownTypes;

namespace project_pizzaria_newbyte.Pages
{
    /// <summary>
    /// Interação lógica para Register_product.xam
    /// </summary>
    public partial class Register_product : Page
    {
        public Register_product()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (nameInput.Text != null && priceInput.Text != null)
            {
                ProdutoModel produto = new ProdutoModel();
                produto.Nome = nameInput.Text;
                produto.Valor = Convert.ToDouble(priceInput.Text);

                ProdutoIDAO produtoIDAO = new ProdutoIDAO();
                produtoIDAO.Create(produto);
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
