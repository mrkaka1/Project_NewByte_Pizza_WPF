using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace project_pizzaria_newbyte.DataBase
{
    class Connection
    {
        private static string host = "localhost";

        private static string port = "3306";

        private static string user = "root";

        private static string password = "root";

        private static string dbname = "newbite";

        private static MySqlConnection connection;

        private static MySqlCommand command;

        public void Connect()
        {
            try
            {
                connection = new MySqlConnection($"server={host};database={dbname};port={port};user={user};password={password}");
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro de conexão." + ex);
            }
        }

        public MySqlCommand Query()
        {
            try
            {
                if (connection == null || connection.State != ConnectionState.Open)
                {
                    throw new InvalidOperationException("Erro no query.");
                }

                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao execultar ação. " + ex);
                throw new Exception("Erro ao execultar ação. " + ex);
            }
        }

        public void Close()
        {
            try
            {

                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao desconectar. " + ex);
                throw new Exception("Erro ao desconectar. " + ex);
            }
        }
    }
}
