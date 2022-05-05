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
        private MonoBehaviour _behaviour;
        protected MonoBehaviour Behaviour { get { return _behaviour; } }

        /*
         * Component Pass throughs which allows you to get a component
         * from the parent MonoBehaviour
         */

        public T GetComponent<T>() {
            return _behaviour.GetComponent<T>();
        }

        public T GetComponentInChildren<T>() {
            return _behaviour.GetComponentInChildren<T>();
        }

        public T GetComponentInParent<T>() {
            return _behaviour.GetComponentInParent<T>();
        }

        public T[] GetComponents<T>() {
            return _behaviour.GetComponents<T>();
        }

        public T[] GetComponentsInChildren<T>() {
            return _behaviour.GetComponentsInChildren<T>();
        }

        public T[] GetComponentsInParent<T>() {
            return _behaviour.GetComponentsInParent<T>();
        }

        /// <summary>
        /// Sets the entity. This should be called from the Behaviour which is 
        /// wishing to act as the controller
        /// </summary>
        internal virtual void SetBehaviour(MonoBehaviour behaviour) {
            _behaviour = behaviour;
        }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
    }
}