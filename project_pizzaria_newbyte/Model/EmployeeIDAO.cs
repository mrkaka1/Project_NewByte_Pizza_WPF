using Org.BouncyCastle.Tls;
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
                
                create.CommandText = $"insert into Funcionario " +
                    $"(nome_fun, email_fun, telefone_fun, cpf_fun, acesso_fun, cargo_fun, senha_fun) " +
                    $"values " +
                    $"(@Nome, @Email, @Telefone, @Cpf, @Acesso, @Cargo, @Senha)";
                
                create.Parameters.AddWithValue("@Nome", employee.Nome);
                create.Parameters.AddWithValue("@Email", employee.Email);
                create.Parameters.AddWithValue("@Telefone", employee.Telefone);
                create.Parameters.AddWithValue("@Cpf", employee.Cpf.Replace("-", "").Replace(".", ""));
                create.Parameters.AddWithValue("@Acesso", employee.Acesso);
                create.Parameters.AddWithValue("@Cargo", employee.Cargo);
                create.Parameters.AddWithValue("@Senha", employee.Senha);
                create.ExecuteNonQuery();
                
                MessageBox.Show("Cadastrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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
            List<EmployeeModel> employees = new List<EmployeeModel>();

            try
            {
                connection.Connect();
                var read = connection.Query();
                read.CommandText = "select * from Funcionario";
                var reader = read.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(new EmployeeModel
                    {
                        Id = reader.GetInt32("id_fun"),
                        Nome = reader.GetString("nome_fun"),
                        Email = reader.GetString("email_fun"),
                        Telefone = reader.GetString("telefone_fun"),
                        Cpf = reader.GetString("cpf_fun"),
                        Acesso = reader.GetString("acesso_fun"),
                        Cargo = reader.GetString("cargo_fun"),
                        Senha = reader.GetString("senha_fun")
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return employees;
        }

        public EmployeeModel ReadById(int id)
        {
            EmployeeModel employee = null;

            try
            {
                connection.Connect();
                var read = connection.Query();
                read.CommandText = "select * from Funcionario where id_fun = @Id";
                read.Parameters.AddWithValue("@Id", id);
                var reader = read.ExecuteReader();

                if (reader.Read())
                {
                    employee = new EmployeeModel
                    {
                        Id = reader.GetInt32("id_fun"),
                        Nome = reader.GetString("nome_fun"),
                        Email = reader.GetString("email_fun"),
                        Telefone = reader.GetString("telefone_fun"),
                        Cpf = reader.GetString("cpf_fun"),
                        Acesso = reader.GetString("acesso_fun"),
                        Cargo = reader.GetString("cargo_fun"),
                        Senha = reader.GetString("senha_fun")
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return employee;
        }

        public void Update(EmployeeModel value)
        {
            try
            {
                connection.Connect();
                var update = connection.Query();
                update.CommandText = "update Funcionario set " +
                    "nome_fun = @Nome, " +
                    "email_fun = @Email, " +
                    "telefone_fun = @Telefone" +
                    "cpf_fun = @Cpf" +
                    "acesso_fun = @Acesso, " +
                    "cargo_fun = @Cargo, " +
                    "senha_fun = @Senha " +
                    "where id_fun = @Id";

                update.Parameters.AddWithValue("@Id", value.Id);
                update.Parameters.AddWithValue("@Nome", value.Nome);
                update.Parameters.AddWithValue("@Email", value.Email);
                update.Parameters.AddWithValue("@Telefone", value.Telefone);
                update.Parameters.AddWithValue("@Cpf", value.Cpf.Replace("-", "").Replace(".", ""));
                update.Parameters.AddWithValue("@Acesso", value.Acesso);
                update.Parameters.AddWithValue("@Cargo", value.Cargo);
                update.Parameters.AddWithValue("@Senha", value.Senha);
                update.ExecuteNonQuery();

                MessageBox.Show("Credenciais atualizadas!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public void Delete(EmployeeModel value)
        {
            try
            {
                connection.Connect();
                var delete = connection.Query();
                delete.CommandText = "delete from funcionario where id_fun = @Id";
                delete.Parameters.AddWithValue("@Id", value.Id);
                delete.ExecuteNonQuery();

                MessageBox.Show("Funcionáiro excluído!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}