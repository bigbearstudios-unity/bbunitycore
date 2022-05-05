using UnityEngine;

namespace BBUnity {
    class SubcomponentController {

        /// <summary>
        /// Uses Reflection to find the SubComponent fields which are assigned to this behaviour.
        /// The subcomponents are returned.
        /// </summary>
        private Subcomponent[] _subcomponents = null;
        public Subcomponent[] Subcomponents {
            get { return _subcomponents ??= Utilities.FindReflectedFields<Subcomponent>(this); }
        }

        public void AwakeAll(MonoBehaviour behaviour) {
            foreach(Subcomponent controller in Subcomponents) {
                controller.SetBehaviour(behaviour);
                controller.Awake();
            }
        }

        public void StartAll() {
            foreach(Subcomponent controller in Subcomponents) {
                controller.Start();
            }
        }

        public void UpdateAll() {
            foreach(Subcomponent controller in Subcomponents) {
                controller.Update();
            }
        }

        public void FixedUpdateAll() {
            foreach(Subcomponent controller in Subcomponents) {
                controller.FixedUpdate();
            }
        }
    }
}