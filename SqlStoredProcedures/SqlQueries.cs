using System.Text;

namespace SqlStoredProcedures
{
    public static class SqlQueries
    {
        //Все авторы по заданному городу
        public static string GetAuthorsFromCityQuery(string city)
        {
            return $"select * from authors where city = '{city}'";
        }

        //имя и фамилия автора и название книги по id книги (пример 'PS2106')
        public static string GetNameAndTitleFromId(string id)
        {
            return new StringBuilder("select au_lname, au_fname, title from authors inner join titleauthor ")
                .Append("inner join titles on titleauthor.title_id = titles.title_id ")
                .Append($"on authors.au_id = titleauthor.au_id where titles.title_id= '{id}'")
                .ToString();
        }

        //количество строк заданной таблицы
        public static string GetLinesCount(string tableName)
        {
            return $"select count(*) from {tableName}";
        }

        //Полная выручка
        public static string GetProceeds()
        {
            return "sum(ytd_sales*price) from titles";
        }
    }
}