using System;
using System.Data.SqlClient;

namespace SqlStoredProcedures
{
    public static class CreatedQueryExecutor
    {
        private static SqlConnection sqlConnection;
        public static void Start(SqlConnection connection)
        {
            sqlConnection = connection;
            ShowSecondPointMenu();
            var number = IntParser.GetInputOrZero(Console.ReadLine());
            ExecuteMenuPoint(number);
        }
        
        private static void ShowSecondPointMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Вывести всех авторов из заданного города");
        }
        
        private static void ExecuteMenuPoint(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("Введите город:");
                    var city = Console.ReadLine();
                    QueryExecutor.ExecuteQuery(SqlQueries.GetAuthorsFromCityQuery(city), sqlConnection);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Введено некорректное значение!");
                    ShowSecondPointMenu();
                    break;
            }
        }
    }
}