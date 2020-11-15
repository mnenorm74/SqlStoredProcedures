namespace SqlStoredProcedures
{
    class Program
    {
        private const string serverName = "DESKTOP-P6TQKTV";
        private const string dbName = "Bursina_Konovalova";
        private static readonly string connectionString = 
            @$"Data Source={serverName};Initial Catalog={dbName};Integrated Security=True";
        
        static void Main(string[] args)
        {
            var connector = new SqlConnector();
            connector.StartSqlInteraction(connectionString);
        }
    }
}