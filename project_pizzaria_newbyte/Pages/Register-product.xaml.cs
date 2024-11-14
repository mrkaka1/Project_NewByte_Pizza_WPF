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
            ProdutoModel refri = new ProdutoModel();
            refri.Id = 9;
            refri.Nome = "Coca-Cola";
            refri.Valor = 7;

            refri.cadastrarProduto();
        }
    }
}
