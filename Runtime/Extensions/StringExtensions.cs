using System.Text.RegularExpressions;

namespace BBUnity.Extensions {
    public static class StringExtensions {

        /// <summary>
        /// Returns the count of the number of complete works in
        /// the string provided.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>The number of words</returns>
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
        /// <returns>True / False if the string contains whitespace</returns>
        public static bool ContainsWhitespace(this string str) {
           return Regex.IsMatch(str, @"\s");
        }

        /// <summary>
        /// Uppercases the first letter of a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>The string with the first letter upper cased</returns>
        public static string UpperCaseFirstLetter(this string str) {
            if (str.Length == 0) {
                return string.Empty;
            }

            char[] a = str.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}