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
    class SupplierIDAO : IDAO<SupplierModel>
    {
        public static Connection connection;

        public SupplierIDAO()
        {
            connection = new Connection();
        }

        public bool Create(SupplierModel supplier)
        {
            

            try
            {
                connection.Connect();

                var create = connection.Query();
                create.CommandText = $"insert into Fornecedor (id_for, nome_for, endereco_for, cnpj_for, cep_for) values (@Id, @Nome, @Endereco, @Cnpj, @Cep)";

                create.Parameters.AddWithValue("@Id", null);
                create.Parameters.AddWithValue("@Nome", supplier.Nome);
                create.Parameters.AddWithValue("@Endereco", supplier.Endereco);
                create.Parameters.AddWithValue("@Cnpj", supplier.CNPJ);
                create.Parameters.AddWithValue("@Cep", supplier.Cep);
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

        public List<SupplierModel> Read()
        {
            List<SupplierModel> employees = new List<SupplierModel>();

            try
            {
                connection.Connect();
                var read = connection.Query();
                read.CommandText = "select * from Fornecedor";
                var reader = read.ExecuteReader();

                while (reader.Read())
                {
                    employees.Add(new SupplierModel
                    {
                        Id = reader.GetInt32("id_for"),
                        Nome = reader.GetString("nome_for"),
                        Endereco = reader.GetString("enderco_for"),
                        CNPJ = reader.GetString("cnpj_for"),
                        Cep = reader.GetString("cep_for")
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return employees;
        }

        public SupplierModel ReadById(int id)
        {
            SupplierModel employee = null;

            try
            {
                connection.Connect();
                var read = connection.Query();
                read.CommandText = "select * from Fornecedor where id_for = @Id";
                read.Parameters.AddWithValue("@Id", id);
                var reader = read.ExecuteReader();

                if (reader.Read())
                {
                    employee = new SupplierModel
                    {
                        Id = reader.GetInt32("id_for"),
                        Nome = reader.GetString("nome_for"),
                        Endereco = reader.GetString("enderco_for"),
                        CNPJ = reader.GetString("cnpj_for"),
                        Cep = reader.GetString("cep_for")
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return employee;
        }

        public void Update(SupplierModel value)
        {
            try
            {
                connection.Connect();
                var update = connection.Query();
                
                update.CommandText = "update Fornecedor set " +
                    "nome_for = @Nome, " +
                    "endereco_for = @Endereco, " +
                    "cnpj_for = @Cnpj, " +
                    "cep_for = @Cep" +
                    "where id_for = @Id";

                update.Parameters.AddWithValue("@Id", value.Id);
                update.Parameters.AddWithValue("@Nome", value.Nome);
                update.Parameters.AddWithValue("@Endereco", value.Endereco);
                update.Parameters.AddWithValue("@Cnpj", value.CNPJ);
                update.Parameters.AddWithValue("@Cep", value.Cep);
                update.ExecuteNonQuery();

                MessageBox.Show("Credenciais atualizadas!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public void Delete(SupplierModel value)
        {
            try
            {
                connection.Connect();
                var delete = connection.Query();
                delete.CommandText = "delete from Fornecedor where id_for = @Id";
                delete.Parameters.AddWithValue("@Id", value.Id);
                delete.ExecuteNonQuery();

                MessageBox.Show("Funcionáiro excluído!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
