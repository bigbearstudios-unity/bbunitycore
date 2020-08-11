using System.Text.RegularExpressions;

/*
 * Please note that all Extensions should be part of .Extensions
 * as to not polute the BBUnity namespace
 */
namespace BBUnity.Extensions {
    public static class StringExtensions {

        /// <summary>
        /// Counts the number of words in a given string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int NumberOfWords(this string str) {
            int wordCount = 0, index = 0;

            while (index < str.Length && char.IsWhiteSpace(str[index])) {
                index++;
            }

            while (index < str.Length) {
                while (index < str.Length && !char.IsWhiteSpace(str[index])) {
                    index++;
                }

                wordCount++;

                while (index < str.Length && char.IsWhiteSpace(str[index])) {
                    index++;
                }
            }

            return wordCount;
        }

        /// <summary>
        /// Returns true if a whitespace character is detected within the string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ContainsWhitespace(this string str) {
           return Regex.IsMatch(str, @"\s");
        }

        /// <summary>
        /// Uppercases the first letter of a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UpperCaseFirstLetter(this string str) {
            if (str.Length == 0) {
                return string.Empty; //Returning empty to maintain the fact we always return a new string
            }

            char[] a = str.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}