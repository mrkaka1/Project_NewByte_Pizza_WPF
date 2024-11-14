using MySql.Data.MySqlClient;
using project_pizzaria_newbyte.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace project_pizzaria_newbyte.Model
{
    class ProdutoModel
    {
        public int Id { get; set; }       
        public string Nome { get; set; }
        //public Blob Foto { get; set; }  
        public float Valor { get; set; }
        //public EstoqueModel Estoque { get; set; }

        public bool cadastrarProduto() {
            try
            {
                var connection = new Connection();

                string insert = $"insert into Produto values({Id}, {Nome}, {Valor});";

                Connection.Connect connect = new Connection.Connect();
                MySqlCommand createQuery = connect.Query();

                createQuery.CommandText = insert;
                createQuery.ExecuteNonQuery();
                return true;
            } catch(Exception ex)
            {
                return false;
            }
        }
    }
}
