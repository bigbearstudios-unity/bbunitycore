using System;
using UnityEngine;

using BBUnity.Extensions;

namespace BBUnity.Utilities {
    public class Create {
        public static GameObject GameObject(string name) {
            GameObject obj = new GameObject(name);
            obj.transform.position = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            return obj;
        }

        public static GameObject GameObject(string name, Transform parent) {
            GameObject obj = new GameObject(name);
            obj.transform.SetParent(parent, true);
            obj.transform.position = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            return obj;
        }

        public static GameObject GameObject(string name, Type[] components) {
            GameObject obj = new GameObject(name, components);
            obj.transform.position = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            return obj;
        }

        public static GameObject GameObject(string name, Transform parent, Type[] components) {
            GameObject obj = new GameObject(name, components);
            obj.transform.SetParent(parent, true);
            obj.transform.position = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            return obj;
        }

        public static T InstantiatedGameObjectWithComponent<T> (GameObject prefab, Transform parentTransform = null) where T : Component {
            GameObject obj = UnityEngine.GameObject.Instantiate<GameObject>(prefab, parentTransform);
            return obj.AddOrGetComponent<T>();
        }
    }
}