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
                create.CommandText = $"insert into Fornecedor (id_for, nome_for, cnpj_for, cep_for, endereco_for) values (@Id, @Nome, @Cnpj, @Cep, @Endereco)";

                create.Parameters.AddWithValue("@Id", null);
                create.Parameters.AddWithValue("@Nome", supplier.Name);
                create.Parameters.AddWithValue("@Cnpj", supplier.CNPJ);
                create.Parameters.AddWithValue("@Cep", supplier.Cep);
                create.Parameters.AddWithValue("@Endereco", supplier.Endereco);
                create.ExecuteNonQuery();

                MessageBox.Show("Cadastrado");
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

        public void Delete(SupplierModel value)
        {
            throw new NotImplementedException();
        }

        public List<SupplierModel> Read()
        {
            throw new NotImplementedException();
        }

        public SupplierModel ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SupplierModel value)
        {
            throw new NotImplementedException();
        }
    }
}
