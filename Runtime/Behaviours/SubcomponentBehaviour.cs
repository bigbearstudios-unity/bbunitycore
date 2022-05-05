using UnityEngine;

namespace BBUnity {

    /// <summary>
    /// The base entity behaviour. Adds Subcomponent control to the BaseBehaviour, this
    /// could also be added via defining your own SubcomponentController on your own
    /// MonoBehaviour.
    /// </summary>
    [AddComponentMenu("")]
    public class SubcomponentBehaviour : BaseBehaviour {

        /// <summary>
        /// The SubcomponentController which is responsible for the control of 
        /// all of the underlying Subcomponents
        /// </summary>
        /// <returns></returns>  
        private SubcomponentController _subcomponentController;

        /// <summary>
        /// Returns all of the Subcomponents 
        /// </summary>
        /// <value></value>
        public Subcomponent[] Subcomponents {
            get {
                return _subcomponentController.Subcomponents;
            }
        }

        /// <summary>
        /// Virtual Awake, must be called when subclassing
        /// </summary>
        protected virtual void Awake() {
            _subcomponentController.AwakeAll(this);
        }

        /// <summary>
        /// Virtual Start, must be called when subclassing
        /// </summary>
        protected virtual void Start() {
            _subcomponentController.StartAll();
        }
    }
}