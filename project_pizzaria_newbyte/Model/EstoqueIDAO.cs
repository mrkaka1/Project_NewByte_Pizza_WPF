using project_pizzaria_newbyte.DataBase;
using project_pizzaria_newbyte.Interface;
using project_pizzaria_newbyte.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace project_pizzaria_newbyte.Model
{
    class EstoqueIDAO : IDAO<EstoqueModel>
    {
        public static Connection connection;

        public EstoqueIDAO()
        {
            connection = new Connection();
        }

        public bool Create(EstoqueModel estoque)
        {
            try
            {
                connection.Connect();

                var create = connection.Query();
                create.CommandText = $"insert into Estoque (id_est, tipo_medida_est, quantidade_est) values (@Id, @Medida, @Quantidade)";

                create.Parameters.AddWithValue("@Id", null);
                create.Parameters.AddWithValue("@Medida", estoque.TipoMedida);
                create.Parameters.AddWithValue("@Quantidade", estoque.Quantidade);
                create.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return true;
        } 
        public List<EstoqueModel> Read()
        {
            throw new NotImplementedException();
        }

        public EstoqueModel ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EstoqueModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(EstoqueModel value)
        {
            throw new NotImplementedException();
        }

    }
}
