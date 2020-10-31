﻿using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace BBUnity {
    public static class Utilities {

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

    public static GameObject CreateGameObject(string name, System.Type[] components) {
        GameObject obj = new GameObject(name, components);
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

        foreach(var gameObject in gameObjects) {
            T[] instances = gameObject.GetComponentsInChildren<T>(includeInactive);
            foreach(T instance in instances) {
                toReturn.Add(instance);
            }
        }

        return toReturn.ToArray();
    }
}

}