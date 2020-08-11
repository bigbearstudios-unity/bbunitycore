using UnityEngine;

/*
 * Please note that all UnityExtensions are included automatically as part of BBUnity
 */
namespace BBUnity {
    public static class GameObjectExtensions {
        public static T AddOrGetComponent<T>(this GameObject gameObject) where T : Component {
            return U.AddOrGetComponent<T>(gameObject);
        }
    }
}