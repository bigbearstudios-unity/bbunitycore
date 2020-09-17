using System;

namespace BBUnity.Extensions {
    public static class ArrayExtensions {

        /// <summary>
        /// Appends a new item to the end of a System.Array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="obj"></param>
        public static T[] Append<T>(this T[] array, T obj) {
            ArrayUtilities.Append(ref array, obj);
            return array;
        }
    }   
}
