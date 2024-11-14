using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_pizzaria_newbyte.DataBase
{
    class Connection
    {
        internal class Connect
        {
            private static string host = "localhost";

            private static string port = "3306";

            //private static string user = "root";

            private static string password = "root";

            //private static string dbname = "bd_escola";

            private static MySqlConnection connection;

            private static MySqlCommand command;

            public Connect()
            {
                try
                {
                    connection = new MySqlConnection($"server={host};database=newbite;port={port};user=root;password={password}");
                    connection.Open();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public MySqlCommand Query()
            {
                try
                {
                    command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;

                    return command;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Close()
            {
                connection.Close();
            }
        }
    }
}
