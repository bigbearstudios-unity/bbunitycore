using UnityEngine;

namespace BBUnity.Controllers {

    /// <summary>
    /// A helper class which allows the finding and control
    /// of all of the MonoControllers which are mounted
    /// </summary>
    class MonoControllers {

        private MonoController[] _controllers = null;
        public MonoController[] All { get { return _controllers; } }

        public MonoControllers(MonoBehaviour behaviour) {
            FindControllers(behaviour);
        }

        /// <summary>
        /// Finds the services and sorts them by priority ready to be processed
        /// in the later calls of Awake, Start, Update and FixedUpdate
        /// </summary>
        /// <param name="behaviour"></param>
        private void FindControllers(MonoBehaviour behaviour) {
            _controllers = Utilities.FindReflectedFields<MonoController>(behaviour);
            System.Array.Sort(_controllers, (MonoController con1, MonoController con2) => {
                return con1.BehaviourPriority.CompareTo(con2.BehaviourPriority);
            });

            foreach(MonoController con in _controllers) {
                con.SetBehaviour(behaviour);
            }
        }

        public void Awake() {
            foreach(MonoController con in _controllers) {
                con.Awake();
            }
        }

        public void Start() {
            foreach(MonoController con in _controllers) {
                con.Start();
            }
        }

        public void Update() {
            foreach(MonoController con in _controllers) {
                con.Update();
            }
        }

        public void FixedUpdate() {
            foreach(MonoController con in _controllers) {
                con.FixedUpdate();
            }
        }

        public void OnDrawGizmos() {
            foreach(MonoController con in _controllers) {
                con.OnDrawGizmos();
            }
        }

        public void Each(System.Action<MonoController> action) {
            foreach(MonoController con in _controllers) {
                action(con);
            }
        }
    }
}