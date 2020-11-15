using System;
using System.Data.SqlClient;

namespace SqlStoredProcedures
{
    public class SqlConnector
    {
        private SqlConnection connection;

        public void StartSqlInteraction(string connectionString)
        {
            using (connection = new SqlConnection(connectionString))
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
            Console.WriteLine("1. Выполнить свой запрос");
            Console.WriteLine("2. Выбрать существующий запрос");
            Console.WriteLine("3. Выбрать существующую хранимую процедуру");
            Console.WriteLine("4. Выход");
            var number = IntParser.GetInputOrZero(Console.ReadLine());
            ExecuteMenuPoint(number);
        }

        private void ExecuteMenuPoint(int number)
        {
            switch (number)
            {
                case 1:
                    UserQueryExecutor.Start(connection);
                    break;
                case 2:
                    CreatedQueryExecutor.Start(connection);
                    break;
                case 3:
                    StoredProceduresExecutor.Start(connection);
                    break;
                case 4:
                    Console.Clear();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Введено некорректное значение!");
                    break;
            }

            BackToMenu();
        }

        private void BackToMenu()
        {
            Console.WriteLine("Нажмите любую клавишу для перехода в меню");
            Console.ReadKey();
            Console.Clear();
            ShowMenu();
        }
    }
}