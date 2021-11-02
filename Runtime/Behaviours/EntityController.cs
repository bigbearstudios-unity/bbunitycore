using System.Collections;
using UnityEngine;

namespace BBUnity {

    /// <summary>
    /// The base Entity Controller. An entity controller allows custom classes to be composed
    /// onto a Unity.Component without the overhead of a full component
    /// </summary>
    public class EntityController {

        /// <summary>
        /// The entity which owns this controller
        /// </summary>
        private EntityBehaviour _entityBehaviour;
        protected EntityBehaviour EntityBehaviour { get { return _entityBehaviour; } }

        public T GetComponent<T>() {
            return _entityBehaviour.GetComponent<T>();
        }

        public T GetComponentInChildren<T>() {
            return _entityBehaviour.GetComponentInChildren<T>();
        }

        public T GetComponentInParent<T>() {
            return _entityBehaviour.GetComponentInParent<T>();
        }

        public T[] GetComponents<T>() {
            return _entityBehaviour.GetComponents<T>();
        }

        public T[] GetComponentsInChildren<T>() {
            return _entityBehaviour.GetComponentsInChildren<T>();
        }

        public T[] GetComponentsInParent<T>() {
            return _entityBehaviour.GetComponentsInParent<T>();
        }

        /// <summary>
        /// Sets the entity. This is called before Awake is called.
        /// </summary>
        public virtual void SetEntity(EntityBehaviour entityBehaviour) {
            _entityBehaviour = entityBehaviour;
        }

        /// <summary>
        /// Gets called when the EntityBehaviours Awake is called
        /// </summary>
        public virtual void Awake() {
          
        }

        /// <summary>
        /// Gets called when the EntityBehaviours Start is called
        /// </summary>
        public virtual void Start() {
          
        }
    }
}