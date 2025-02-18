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
                    $"(nome_pro, valor_pro, tipo_medida_pro, quantidade_pro) " +
                    $"values " +
                    $"(@Nome, @Valor, @Tipo, @Quantidade)";

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
            throw new NotImplementedException();
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
