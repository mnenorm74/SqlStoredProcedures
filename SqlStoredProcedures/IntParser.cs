namespace SqlStoredProcedures
{
    public static class IntParser
    {
        public static int GetInputOrZero(string input)
        {
            var parsed = int.TryParse(input, out var number);
            return parsed ? number : 0;
        }
    }
}