using System;

using UnityEngine;

namespace BBUnity.Controllers {

    public class InvalidMonoControllerBehaviour : Exception {
        public InvalidMonoControllerBehaviour() : base() { }
        public InvalidMonoControllerBehaviour(string message) : base(message) { }
        public InvalidMonoControllerBehaviour(string message, Exception inner) : base(message, inner) { }
    }

    /// <summary>
    /// The base service
    /// </summary>
    [System.Serializable]
    public class MonoController {

        /// <summary>
        /// The MonoBehaviour which owns the controller.
        /// </summary>
        private MonoBehaviour _behaviour;
        protected MonoBehaviour Behaviour { get { return _behaviour; } }

        /// <summary>
        /// Constructor. Please note that a default constructor with no default parameters is
        /// important for all MonoControllers as the easiest way to manage their values would be
        /// via the Unity Editor
        /// </summary>
        public MonoController() { }

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

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void OnDrawGizmos() { }

        /// <summary>
        /// Sets the entity. This should be called from the Behaviour which is 
        /// wishing to act as the controller
        /// </summary>
        internal void SetBehaviour(MonoBehaviour behaviour) {
            _behaviour = behaviour;
        }

        /// <summary>
        /// Finds the the MonoController instances which are defined as private instance
        /// members on the behaviour
        /// </summary>
        /// <param name="behaviour"></param>
        static public MonoController[] FindControllers(MonoBehaviour behaviour) {
            if(behaviour == null) { throw new InvalidMonoControllerBehaviour(); }

            MonoController[] controllers = Utilities.FindReflectedFields<MonoController>(behaviour);
            foreach(MonoController controller in controllers) {
                controller.SetBehaviour(behaviour);
            }

            return controllers;
        }

        static public void AwakeControllers(MonoController[] controllers) {
            foreach(MonoController controller in controllers) {
                controller.Awake();
            }
        }

        static public void StartControllers(MonoController[] controllers) {
            foreach(MonoController controller in controllers) {
                controller.Start();
            }
        }

        static public void UpdateControllers(MonoController[] controllers) {
            foreach(MonoController controller in controllers) {
                controller.Update();
            }
        }

        static public void OnDrawGizmosControllers(MonoController[] controllers) {
            foreach(MonoController controller in controllers) {
                controller.OnDrawGizmos();
            }
        }
    }
}