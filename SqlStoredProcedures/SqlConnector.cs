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
                    ExecuteFirstPoint();
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

        private void ExecuteFirstPoint()
        {
            Console.Clear();
            Console.WriteLine("Введите запрос:");
            var query = Console.ReadLine();
            ExecuteQuery(query);
        }

        private void ExecuteQuery(string query)
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