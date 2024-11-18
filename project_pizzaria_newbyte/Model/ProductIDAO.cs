using project_pizzaria_newbyte.DataBase;
using project_pizzaria_newbyte.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace project_pizzaria_newbyte.Model
{
    class ProductIDAO : IDAO<ProductModel>
    {
        public static Connection connection;

        public ProductIDAO() { 
            connection = new Connection();
        }

        public bool Create(ProductModel produto)
        {
            try
            {
                connection.Connect();

                var create = connection.Query();
                create.CommandText = $"insert into Produto " +
                    $"(id_pro, nome_pro, foto_pro, valor_pro, tipo_medida_pro, quantidade_pro) " +
                    $"values " +
                    $"(null, @Nome, null, @Valor, @Tipo, @Quantidade)";

                create.Parameters.AddWithValue("@Nome", produto.Nome);
                create.Parameters.AddWithValue("@Valor", produto.Valor);
                create.Parameters.AddWithValue("@Tipo", produto.Medida);
                create.Parameters.AddWithValue("@Quantidade", produto.Quantidade);

                create.ExecuteNonQuery();
                MessageBox.Show("Produto cadastrado.");

            } catch (Exception ex) {
                MessageBox.Show("Erro ao cadastrar produto. " + ex);
                return false;
            } finally
            {
                connection.Close();
            }

            return true;
        }

        public void Delete(ProductModel value)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> Read()
        {
            List<ProductModel> products = new List<ProductModel> ();

            try
            {
                connection.Connect();
                var read = connection.Query();
                read.CommandText = "select * from Produto;";

                var reader = read.ExecuteReader();

                while(reader.Read())
                {
                    ProductModel product = new ProductModel();
                    product.Id = reader.GetInt32("id_pro");
                    product.Nome = reader.GetString("nome_pro");
                    product.Valor = reader.GetDouble("valor_pro");
                    product.Medida = reader.GetString("tipo_medida_pro");
                    product.Quantidade = reader.GetDouble("quantidade_pro");

                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar produtos." + ex);
                return products;
            }

            return products;
        }

        public ProductModel ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductModel value)
        {
            throw new NotImplementedException();
        }
    }
}
