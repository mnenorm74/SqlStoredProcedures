using System;
using System.Data.SqlClient;

namespace SqlStoredProcedures
{
    public static class UserQueryExecutor
    {
        public static void Start(SqlConnection connection)
        {
            Console.Clear();
            Console.WriteLine("Введите запрос:");
            var query = Console.ReadLine();
            QueryExecutor.ExecuteQuery(query, connection);
        }
    }
}