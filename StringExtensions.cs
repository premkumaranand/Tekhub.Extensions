using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tekhub.Extensions
{
    public static class StringExtensions
    {
        public static string GetLastUrlSegment(this string url)
        {
            url = url.Trim('/');
            return url.Split('/').Last();
        }

        public static string GetFirstUrlSegment(this string url)
        {
            url = url.Trim('/');
            return url.Split('/').First();
        }

        public static string GetUrlSegment(this string url, int index)
        {
            url = url.Trim('/');
            var urlParts = url.Split('/');
            return urlParts[index];
        }

        public static T ConvertToEnum<T>(this string enumValue)
        {
            enumValue = enumValue.Replace(" ", "");
            return (T)Enum.Parse(typeof(T), enumValue);
        }

        public static string ToCamelCase(this string theString)
        {
            // If there are 0 or 1 characters, just return the string.
            if (theString == null || theString.Length < 2)
                return theString;

            var rgx = new Regex("[^a-zA-Z ]");
            theString = rgx.Replace(theString, " ");

            // Split the string into words.
            var words = theString.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            var result = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                result +=
                    words[i].Substring(0, 1).ToUpper() +
                    words[i].Substring(1);
            }

            return result;
        }

        public static string ToPascalCase(this string theString)
        {
            var camelCase = theString.ToCamelCase();
            return string.Format("{0}{1}", camelCase.Substring(0, 1).ToUpper(), camelCase.Substring(1));
        }

        public static string EncloseForIndexer(this string value)
        {
            return string.Format("indexermatch {0} indexermatch", value);
        }
    }
}
