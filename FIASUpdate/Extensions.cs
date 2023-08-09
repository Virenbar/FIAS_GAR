namespace FIASUpdate
{
    internal static class Extensions
    {
        public static string TrimSpaces(this string str)
        {
            str = str.Trim();
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            return str;
        }
    }
}