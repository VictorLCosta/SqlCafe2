using System;

namespace SqlCafe2.Extensions
{
    public static class StringExtensions
    {
        public static bool In(this string value, params string[] stringValues)
        {
            foreach (string otherValue in stringValues)
            if (string.Compare(value, otherValue) == 0)
                return true;

            return false;
        }

        public static bool IsDate(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return DateTime.TryParse(value, out DateTime dt);
            }
            else
            {
                return false;
            }
        }

        public static bool IsNumeric(this string theValue)
        {
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out long retNum);
        }

        public static string Right(this string value, int length)
        {
            return value != null && value.Length > length ? value.Substring(value.Length - length) : value!;
        }

        public static string Left(this string value, int length)
        {
            return value != null && value.Length > length ? value.Substring(0, length) : value!;
        }

    }
}