using UnityEngine;
using BBUnity.SceneManagement;

namespace BBUnity.Templates {

    class LoadableReference {

        /// <summary>
        /// The prefab for the reference for the object to be
        /// instanciated
        /// </summary>
        GameObject _prefab;

        /// <summary>
        /// The SceneReference of the item to be loaded
        /// </summary>
        SceneReference _sceneReference;

        /// <summary>
        /// The name of the item which is going to be loaded. T
        /// </summary>
        string _name;
    }
}