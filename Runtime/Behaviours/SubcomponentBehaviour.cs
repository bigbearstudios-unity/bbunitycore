using UnityEngine;

namespace BBUnity {

    /// <summary>
    /// The base entity behaviour. Entities give more control than a BaseBehaviour and enable 
    /// Controllers to use used as part of the component flow. Please note that the Awake / Start
    /// methods must be called if overridden
    /// </summary>
    public class SubcomponentBehaviour : BaseBehaviour {


        /// <summary>
        /// Uses Reflection to find the SubComponent fields which are assigned to this behaviour.
        /// The subcomponents are returned.
        /// </summary>
        private Subcomponent[] _subcomponents;
        public Subcomponent[] Subcomponents {
            get { return _subcomponents ??= Utilities.FindReflectedFields<Subcomponent>(this); }
        }

        /// <summary>
        /// Virtual Awake, must be overriden in subclasses
        /// </summary>
        protected virtual void Awake() {
            foreach(Subcomponent controller in Subcomponents) {
                controller.SetEntity(this);
                controller.Awake();
            }
        }

        /// <summary>
        /// Virtual Start, must be overriden in subclasses
        /// </summary>
        protected virtual void Start() {
            foreach(Subcomponent controller in Subcomponents) {
                controller.Start();
            }
        }
    }
}