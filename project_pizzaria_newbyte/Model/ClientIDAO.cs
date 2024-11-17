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
    class ClientIDAO : IDAO<ClientModel>
    {
        public static Connection connection;

        public ClientIDAO()
        {
            connection = new Connection();
        }

        public bool Create(ClientModel user)
        {
            try
            {
                connection.Connect();

                var create = connection.Query();
                create.CommandText = $"insert into Cliente (id_cli, nome_cli, email_cli, cpf_cli,senha_cli) values (@Id, @Nome,@email, @cpf, @senha)";

                create.Parameters.AddWithValue("@Id", null);
                create.Parameters.AddWithValue("@Nome", user.Name);
                create.Parameters.AddWithValue("@email", user.Email);
                create.Parameters.AddWithValue("@cpf", user.Cpf);
                create.Parameters.AddWithValue("@senha", user.Password);

                create.ExecuteNonQuery();

                MessageBox.Show("Cadastrado");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                return false;
            }
            finally
            {
                connection.Close();
            }

            return true;
        }
        public List<ClientModel> Read()
        {

            throw new NotImplementedException();
            /*try
            {
                connection.Connect();
                var read = connection.Query();
                read.CommandText = "select * from Estoque;";
            } catch (Exception ex)
            {

            }*/
        }

        public ClientModel ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(ClientModel value)
        {
            throw new NotImplementedException();
        }
    }
}
