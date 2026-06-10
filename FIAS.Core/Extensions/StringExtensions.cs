using System;

namespace FIAS.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Является ли строка GUID
        /// </summary>
        public static bool IsGUID(this string str)
        {
            if (string.IsNullOrEmpty(str)) { return false; }
            if (str.Length != 36) { return false; }
            return Guid.TryParse(str, out var _);
        }

        /// <summary>
        /// Получить указанное количество символов справа
        /// </summary>
        public static string Right(this string value, int length)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            return value.Length <= length ? value : value.Substring(value.Length - length);
        }

        /// <summary>
        /// Удалить все повторяющиеся пробелы
        /// </summary>
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