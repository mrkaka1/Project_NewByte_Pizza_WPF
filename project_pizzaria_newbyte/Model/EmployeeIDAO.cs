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
    class EmployeeIDAO : IDAO<EmployeeModel>
    {
        public static Connection connection;

        public EmployeeIDAO()
        {
            connection = new Connection();
        }

        public bool Create(EmployeeModel employee)
        {
            try
            {
                connection.Connect();

                var create = connection.Query();
                create.CommandText = $"insert into Funcionario (id_fun, nome_fun, email_fun, acesso_fun, cargo_fun, senha_fun, repetir_senha_fun) values (@Id, @Nome, @email, @acesso, @cargo, @senha, @repetirSenha)";

                create.Parameters.AddWithValue("@Id", null);
                create.Parameters.AddWithValue("@Nome", employee.Nome);
                create.Parameters.AddWithValue("@email", employee.Email);
                create.Parameters.AddWithValue("@acesso", employee.Acesso);
                create.Parameters.AddWithValue("@cargo", employee.Cargo);
                create.Parameters.AddWithValue("@senha", employee.Senha);
                create.Parameters.AddWithValue("@repetirSenha", employee.Repetir_Senha);
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
        public List<EmployeeModel> Read()
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

        public EmployeeModel ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeModel value)
        {
            throw new NotImplementedException();
        }

        public void Delete(EmployeeModel value)
        {
            throw new NotImplementedException();
        }
    }
}
