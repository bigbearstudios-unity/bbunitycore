using System.Collections;
using UnityEngine;

namespace BBUnity {

    /// <summary>
    /// The base Entity Controller. An entity controller allows custom classes to be composed
    /// onto a Unity.Component without the overhead of a full component
    /// </summary>
    public class Subcomponent {

        /// <summary>
        /// The entity which owns this controller
        /// </summary>
        private SubcomponentBehaviour _subcomponentBehaviour;
        protected SubcomponentBehaviour SubcomponentBehaviour { get { return _subcomponentBehaviour; } }

        public T GetComponent<T>() {
            return _subcomponentBehaviour.GetComponent<T>();
        }

        public T GetComponentInChildren<T>() {
            return _subcomponentBehaviour.GetComponentInChildren<T>();
        }

        public T GetComponentInParent<T>() {
            return _subcomponentBehaviour.GetComponentInParent<T>();
        }

        public T[] GetComponents<T>() {
            return _subcomponentBehaviour.GetComponents<T>();
        }

        public T[] GetComponentsInChildren<T>() {
            return _subcomponentBehaviour.GetComponentsInChildren<T>();
        }

        public T[] GetComponentsInParent<T>() {
            return _subcomponentBehaviour.GetComponentsInParent<T>();
        }

        /// <summary>
        /// Sets the entity. This is called before Awake is called.
        /// </summary>
        internal virtual void SetEntity(SubcomponentBehaviour entityBehaviour) {
            _subcomponentBehaviour = entityBehaviour;
        }

        /// <summary>
        /// Gets called when the SubcomponentBehaviour Awake is called
        /// </summary>
        public virtual void Awake() { }

        /// <summary>
        /// Gets called when the SubcomponentBehaviour Start is called
        /// </summary>
        public virtual void Start() { }
    }
}