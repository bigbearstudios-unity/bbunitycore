using System.Collections.Generic;

namespace BBUnity.Conversion {
    public static class ListTo {

        /// <summary>
        /// Converts a List into a string using the seperator provided.
        /// </summary>
        /// <param name="list">The list to be processed</param>
        /// <param name="seperator">The seperator, defaults to -</param>
        /// <returns>The new string</returns>
        public static string String(List<string> list, string seperator = "-") {
            return string.Join(seperator, list);
        }
    }
}