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
    class ProdutoIDAO : IDAO<ProdutoModel>
    {
        public static Connection connection;

        public ProdutoIDAO() { 
            connection = new Connection();
        }

        public bool Create(ProdutoModel produto)
        {
            try
            {
                connection.Connect();

                var create = connection.Query();
                create.CommandText = $"insert into Produto (id_pro, nome_pro, valor_pro) values (@Id, @Nome, @Valor)";

                create.Parameters.AddWithValue("@Id", null);
                create.Parameters.AddWithValue("@Nome", produto.Nome);
                create.Parameters.AddWithValue("@Valor", produto.Valor);
                create.ExecuteNonQuery();

            } catch (Exception ex) {
                return false;
            } finally
            {
                connection.Close();
            }

            return true;
        }

        public void Delete(ProdutoModel value)
        {
            throw new NotImplementedException();
        }

        public List<ProdutoModel> Read()
        {
            throw new NotImplementedException();
        }

        public ProdutoModel ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProdutoModel value)
        {
            throw new NotImplementedException();
        }
    }
}
