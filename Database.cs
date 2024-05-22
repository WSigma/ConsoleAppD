using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleAppDk
{
    internal class Database
    {
        MySqlCommand sqlCommand;
        MySqlConnection connection;
        public Database()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "dk";
            connection = new MySqlConnection(builder.ConnectionString);
            sqlCommand = connection.CreateCommand();
            try
            {
                ConnectionOpen();
                ConnectionClose();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
        private void ConnectionClose()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        private void ConnectionOpen()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        internal List<Dk> getAlldk()
        {
            List<Dk> dk = new List<Dk>();
            sqlCommand.CommandText = "SELECT `data1`, `data2`, `data3`, `data4`, `data5`, `data6` FROM `dk` WHERE 1";
            ConnectionOpen();
            using (MySqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Dk d = new Dk(dr.GetInt32("data1"), dr.GetString("data2"), dr.GetString("data3"), dr.GetString("data4"), dr.GetInt32("data5"), dr.GetInt32("data6"));
                    dk.Add(d);
                }
            }
            ConnectionClose();
            return dk;
        }
    }
}