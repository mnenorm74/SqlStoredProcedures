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
            Console.WriteLine("2. Вывести имя и фамилия автора и название книги по id книги");
            Console.WriteLine("3. Вывести количество строк заданной таблицы");
            Console.WriteLine("4. Вывести полную выручку по всем книгам");
        }
        
        private static void ExecuteMenuPoint(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("Введите город, например, Москва");
                    var city = Console.ReadLine();
                    QueryExecutor.ExecuteQuery(SqlQueries.GetAuthorsFromCityQuery(city), sqlConnection);
                    break;
                case 2:
                    Console.WriteLine("Введите id книги, например PS2106");
                    var id = Console.ReadLine();
                    QueryExecutor.ExecuteQuery(SqlQueries.GetNameAndTitleFromId(id), sqlConnection);
                    break;
                case 3:
                    Console.WriteLine("Введите название таблицы, например, authors");
                    var name = Console.ReadLine();
                    QueryExecutor.ExecuteQuery(SqlQueries.GetLinesCount(name), sqlConnection);
                    break;
                case 4:
                    QueryExecutor.ExecuteQuery(SqlQueries.GetProceeds(), sqlConnection);
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