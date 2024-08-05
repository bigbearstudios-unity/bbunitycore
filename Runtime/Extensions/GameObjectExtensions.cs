using UnityEngine;

/*
 * Please note that all Extensions should be part of .Extensions
 * as to not polute the BBUnity namespace
 */
namespace BBUnity.Extensions {
    public static class GameObjectExtensions {

        /// <summary>
        /// Adds or Gets a component from a GameObject. This will check to see if a GameObject
        /// has the Component of T, otherwise will add said component and return it.
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T AddOrGetComponent<T>(this GameObject obj) where T : Component {
            return obj.GetComponent<T>() ?? obj.AddComponent<T>();
        }
    }
}