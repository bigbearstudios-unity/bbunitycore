using System;

namespace BBUnity {
    public static class ArrayUtilities {

        public static void Append<T>(ref T[] array, T obj) {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = obj;
        }

        public static T[] Append<T>(T[] array, T obj) {
            T[] newArray = new T[array.Length + 1];
            for(int i = 0; i < array.Length; ++i) {
                newArray[i] = array[i];
            }

            newArray[newArray.Length - 1] = obj;

            return newArray;
        }
    }
}
