using System;
using System.Data.SqlClient;

namespace SqlStoredProcedures
{
    public static class QueryExecutor
    {
        public static void ExecuteQuery(string query, SqlConnection connection)
        {
            var command = new SqlCommand(query, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var elementNumber = reader.FieldCount;
                    for (var i = 0; i < elementNumber; i++)
                    {
                        Console.Write($"{reader[i]}\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}