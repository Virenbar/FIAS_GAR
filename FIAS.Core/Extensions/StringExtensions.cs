﻿using System;

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