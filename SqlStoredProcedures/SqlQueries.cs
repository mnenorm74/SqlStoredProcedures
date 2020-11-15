namespace SqlStoredProcedures
{
    public static class SqlQueries
    {
        public static string GetAuthorsFromCityQuery(string city)
        {
            return $"select * from authors where city = '{city}'";
        }
    }
}