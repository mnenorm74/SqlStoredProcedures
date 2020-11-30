using System;
using System.Data;
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
                while (reader.HasRows)
                {
                    Print(reader);

                    if (!reader.NextResult())
                        return;
                }
            }
        }

        private static void Print(IDataReader reader)
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