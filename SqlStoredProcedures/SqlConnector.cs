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
            Console.WriteLine("1. Выполнить свой запрос");
            Console.WriteLine("2. Выбрать существующий запрос");
            Console.WriteLine("3. Выбрать существующую хранимую процедуру");
            Console.WriteLine("4. Выход");
            var number = GetInputOrZero(Console.ReadLine());
            ExecuteMenuPoint(number);
        }

        private int GetInputOrZero(string input)
        {
            var parsed = int.TryParse(input, out var number);
            return parsed ? number : 0;
        }
        
        private void ExecuteMenuPoint(int number)
        {
            switch (number)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Введено некорректное значение!");
                    ShowMenu();
                    break;
            }
        }
    }
}