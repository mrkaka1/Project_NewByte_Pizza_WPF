using MySql.Data.MySqlClient;
using project_pizzaria_newbyte.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace project_pizzaria_newbyte.Model
{
    class ProductModel
    {
        public int Id { get; set; }       
        public string Nome { get; set; }
        public string Foto { get; set; } = null;
        public double Valor { get; set; }
        public string Medida { get; set; }
        public double Quantidade {  get; set; }
    }
}
