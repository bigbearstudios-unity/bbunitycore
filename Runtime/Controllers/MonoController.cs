using UnityEngine;

namespace BBUnity.Controllers {

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

        [SerializeField, Tooltip("The priority of the behaviour when it comes to being called alongside other behaviours. The lowest priority will get processed first (Can be below 0)")]
        private int _behaviourPriority;
        public int BehaviourPriority { get { return _behaviourPriority; } }

        /// <summary>
        /// Constructor. Please note that a default constructor with no default parameters is
        /// important for all MonoControllers as the easiest way to manage their values would be
        /// via the Unity Editor
        /// </summary>
        public MonoController() {

        }

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
        internal void SetBehaviour(MonoBehaviour behaviour) {
            _behaviour = behaviour;
        }

        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
        public virtual void OnDrawGizmos() { }
    }
}