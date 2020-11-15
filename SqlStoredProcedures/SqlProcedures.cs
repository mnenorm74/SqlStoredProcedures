namespace SqlStoredProcedures
{
    public static class SqlProcedures
    {
        //Содержимое таблицы authors
        public static string GetAuthors()
        {
            return "exec GetAuthors";
        }
        
        //Выводит цену на заданную книгу
        public static string GetPrice(string name)
        {
            return $"exec GetPrice '{name}'";
        }
    }
}