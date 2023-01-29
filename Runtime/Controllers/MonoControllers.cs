using System;

using UnityEngine;

namespace BBUnity.Controllers {
    /// <summary>
    /// Allows easier controller over multiple controllers
    /// </summary>
    public class MonoControllers {

        BaseBehaviour _behaviour;
        MonoController[] _controllers;

        /// <summary>
        /// 
        /// </summary>
        public MonoControllers(BaseBehaviour behaviour) { 
            _behaviour = behaviour;
            _controllers = FindControllers(behaviour);
        }

        /// <summary>
        /// Finds the the MonoController instances which are defined as private instance
        /// members on the behaviour
        /// </summary>
        /// <param name="behaviour"></param>
        private MonoController[] FindControllers(MonoBehaviour behaviour) {
            if(behaviour == null) { throw new InvalidMonoControllerBehaviour(); }

            MonoController[] controllers = Utilities.FindReflectedFields<MonoController>(behaviour);
            foreach(MonoController controller in controllers) {
                controller.SetBehaviour(behaviour);
            }

            return controllers;
        }

        public void Awake() {
            foreach(MonoController controller in _controllers) {
                controller.Awake();
            }
        }

        public void Start() {
            foreach(MonoController controller in _controllers) {
                controller.Start();
            }
        }

        public void Update() {
            foreach(MonoController controller in _controllers) {
                controller.Update();
            }
        }

        public void OnDrawGizmos() {
            foreach(MonoController controller in _controllers) {
                controller.OnDrawGizmos();
            }
        }
    }
}