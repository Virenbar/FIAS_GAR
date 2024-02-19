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
            if (str.Length != 36) { return false; }
            return Guid.TryParse(str, out var _);
        }
    }
}