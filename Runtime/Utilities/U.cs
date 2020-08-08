using UnityEngine;

public static class U {

    /*
     * GameObject Creation
     */

    public static GameObject CreateGameObject(string name) {
        return new GameObject(name);
    }

    public static GameObject CreateGameObject(string name, Transform parent) {
        GameObject obj = new GameObject(name);
        obj.transform.parent = parent;
        return obj;
    }

    public static GameObject CreateGameObject(string name, Transform parent, System.Type[] components) {
        GameObject obj = new GameObject(name, components);
        obj.transform.parent = parent;
        return obj;
    }

    public static T CreateGameObject<T>() where T : Component {
        return AddOrGetComponent<T>(new GameObject());
    }

    public static T CreateGameObject<T>(string name, Transform parent) where T : Component {
        GameObject obj = CreateGameObject(name, parent);
        return AddOrGetComponent<T>(obj);
    }

    /*
     * Instanciation
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
     * Component Based GameObject Creation
     */
    
    public static T CreateGameObject<T>(string name) {
        return new GameObject(name, typeof(T)).GetComponent<T>();
    }

    public static T CreateGameObject<T>(string name, System.Action<T> func) {
        return Tap(new GameObject(name, typeof(T)).GetComponent<T>(), func);
    }

    public static T CreateGameObject<T>(string name, System.Type[] components) {
        return new GameObject(name, components).GetComponent<T>();
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
}
