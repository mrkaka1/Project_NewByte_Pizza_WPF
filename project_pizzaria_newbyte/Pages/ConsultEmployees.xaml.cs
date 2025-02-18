using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace project_pizzaria_newbyte.Pages
{
    public partial class ConsultEmployees : Window
    {
        public ConsultEmployees()
        {
            InitializeComponent();
            this.Loaded += ConsultEmployees_Loaded;
        }

        private void ConsultEmployees_Loaded(object sender, RoutedEventArgs e)
        {
            LoadEmployeesData();
        }

        private void LoadEmployeesData()
        {
            var connection = new DataBase.Connection();

            try
            {
                connection.Connect();

                var query = connection.Query();
                query.CommandText = "select nome_fun as Nome, email_fun as Email, telefone_fun as Telefone, cpf_fun as CPF, acesso_fun as Acesso, cargo_fun as Cargo from Funcionario";

                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    DataGridEmployees.ItemsSource = dt.DefaultView;
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
