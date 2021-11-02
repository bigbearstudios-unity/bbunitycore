using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace BBUnity {
    public static class Utilities {

        /*
         * Reflection 
         */
        public static T[] FindReflectedFields<T>(object obj) {
            System.Reflection.BindingFlags bindingFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
            System.Reflection.FieldInfo[] fields = obj.GetType().GetFields(bindingFlags);

            List<T> toReturn = new List<T>();
            foreach(System.Reflection.FieldInfo field in fields) {
                if(field.FieldType.IsSubclassOf(typeof(T))){
                    toReturn.Add((T)field.GetValue(obj));
                }
            }

            return toReturn.ToArray();
        }

        /*
         * GameObject Creation
         */

        public static GameObject CreateGameObject(string name) {
            return new GameObject(name);
        }

        public static GameObject CreateGameObject(string name, Transform parent) {
            GameObject obj = new GameObject(name);
            obj.transform.SetParent(parent, true);
            return obj;
        }

        public static GameObject CreateGameObject(string name, System.Type[] components) {
            GameObject obj = new GameObject(name, components);
            return obj;
        }

        public static GameObject CreateGameObject(string name, Transform parent, System.Type[] components) {
            GameObject obj = new GameObject(name, components);
            obj.transform.SetParent(parent, true);
            return obj;
        }

        public static T CreateGameObject<T>() where T : Component {
            return AddOrGetComponent<T>(new GameObject());
        }

        public static T CreateGameObject<T>(string name) where T : Component {
            return AddOrGetComponent<T>(CreateGameObject(name));
        }

        public static T CreateGameObject<T>(string name, System.Type[] components) where T : Component {
            return AddOrGetComponent<T>(CreateGameObject(name, components));
        }

        public static T CreateGameObject<T>(string name, Transform parent) where T : Component {
            return AddOrGetComponent<T>(CreateGameObject(name, parent));
        }

        public static T CreateGameObject<T>(string name, Transform parent, System.Type[] components) where T : Component {
            return AddOrGetComponent<T>(CreateGameObject(name, parent, components));
        }

        /*
         * Instantiation
         */

        public static T InstantiateWithComponent<T>(GameObject original) where T : Component {
            GameObject obj = GameObject.Instantiate<GameObject>(original);
            return AddOrGetComponent<T>(obj);
        }

        public static T InstantiateWithComponent<T>(GameObject original, Transform parent) where T : Component {
            GameObject obj = GameObject.Instantiate<GameObject>(original, parent);
            return AddOrGetComponent<T>(obj);
        }

        /*
         * Component Based GameObject Manipulation
         */ 

        public static T AddOrGetComponent<T>(GameObject obj) where T : Component {
            T component = obj.GetComponent<T>();
            if (component == null) {
                component = obj.AddComponent<T>();
            }

            return component;
        }

        /*
         * General Utilities
         */

        public static T Tap<T>(T obj, System.Action<T> action) {
            action(obj);
            return obj;
        }

        /*
         * Scene Management
         */

        public static T[] FindAllInstancesInActiveScene<T>(bool includeInactive = false) {
            List<T> toReturn = new List<T>();
            Scene scene = SceneManager.GetActiveScene();
            GameObject[] gameObjects = scene.GetRootGameObjects();

            if(includeInactive) {
                foreach(GameObject gameObject in gameObjects) {
                    T[] instances = gameObject.GetComponentsInChildren<T>(includeInactive);
                    foreach(T instance in instances) {
                        toReturn.Add(instance);
                    }
                }
            } else {
                foreach(GameObject gameObject in gameObjects) {
                    if(gameObject.activeSelf) {
                        T[] instances = gameObject.GetComponentsInChildren<T>();
                        foreach(T instance in instances) {
                            toReturn.Add(instance);
                        }
                    }
                }
            }

            return toReturn.ToArray();
        }
    }
}