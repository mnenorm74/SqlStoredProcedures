using System;
using System.Data.SqlClient;

namespace SqlStoredProcedures
{
    public static class StoredProceduresExecutor
    {
        private static SqlConnection sqlConnection;
        public static void Start(SqlConnection connection)
        {
            sqlConnection = connection;
            ShowThirdPointMenu();
            var number = IntParser.GetInputOrZero(Console.ReadLine());
            ExecuteThirdMenuPoint(number);
        }
        
        private static void ShowThirdPointMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Вывести всех авторов и информацию о них");
            Console.WriteLine("2. Вывести цену на заданную книгу");
        }
        
        private static void ExecuteThirdMenuPoint(in int number)
        {
            switch (number)
            {
                case 1:
                    QueryExecutor.ExecuteQuery(SqlProcedures.GetAuthors(), sqlConnection);
                    break;
                case 2:
                    Console.WriteLine("Введите название книги, например, Net Etiquette");
                    var name = Console.ReadLine();
                    QueryExecutor.ExecuteQuery(SqlProcedures.GetPrice(name), sqlConnection);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Введено некорректное значение!");
                    ShowThirdPointMenu();
                    break;
            }
        }
    }
}