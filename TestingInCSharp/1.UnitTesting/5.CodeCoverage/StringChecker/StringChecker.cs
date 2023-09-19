namespace StringChecker
{
    public class StringChecker
    {
        public bool IsStringLong(string input)
        {
            if (input.Length > 6)
            {
                return true;
            }

            return false;
        }
    }
}