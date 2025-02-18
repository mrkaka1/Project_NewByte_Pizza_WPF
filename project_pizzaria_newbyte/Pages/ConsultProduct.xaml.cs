using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica interna para ConsultProduct.xaml
    /// </summary>
    public partial class ConsultProduct : Window
    {
        public ConsultProduct()
        {
            InitializeComponent();
            this.Loaded += ConsultProds_Loaded;
        }

        private void ConsultProds_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProdsData();
        }

        private void LoadProdsData()
        {
            var connection = new DataBase.Connection();

            try
            {
                connection.Connect();

                var query = connection.Query();
                query.CommandText = "select nome_pro as Produto, valor_pro as Valor, tipo_medida_pro as Medida, quantidade_pro as Quantidade from Produto";

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    DataGridProds.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
