using System;
using System.Data.SqlClient;

namespace SqlStoredProcedures
{
    public class SqlConnector
    {
        public void StartSqlInteraction(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    Console.WriteLine("Не удалось установить подключение к БД");
                    return;
                }
                ShowMenu();
            }
        }

        private void ShowMenu()
        {
            
        }
    }
}