﻿using MySql.Data.MySqlClient;
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
    /// Lógica interna para ConsultSupplier.xaml
    /// </summary>
    public partial class ConsultSupplier : Window
    {
        public ConsultSupplier()
        {
            InitializeComponent();
            this.Loaded += ConsultSupplier_Loaded;
        }

        private void ConsultSupplier_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSupplierData();
        }

        private void LoadSupplierData()
        {
            var connection = new DataBase.Connection();

            try
            {
                // Estabelece a conexão
                connection.Connect();

                // Prepara a consulta
                var query = connection.Query();
                query.CommandText = "select nome_for as Fornecedor, cnpj_for as CNPJ, cep_for as CEP, endereco_for as Endereco from Fornecedor";

                // Executa a consulta
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Configura o DataGrid
                    DataGridSupplier.ItemsSource = dt.DefaultView;
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
