using UnityEngine;

namespace BBUnity.Controllers {

    /// <summary>
    /// 
    /// </summary>
    [AddComponentMenu("")]
    public abstract class MonoControllerBehaviour : BaseBehaviour {

        /// <summary>
        /// The SubcomponentController which is responsible for the control of 
        /// all of the underlying Subcomponents
        /// </summary>
        /// <returns></returns>  
        private MonoControllers _monoControllers;

        private bool Initialized { get { return _monoControllers != null; } }
        private bool RequiresInitialization { get { return !Initialized; } }

        /// <summary>
        /// Virtual Awake, must be called when subclassing
        /// </summary>
        protected virtual void Awake() {
            _monoControllers = new MonoControllers(this);
            _monoControllers.Awake();
        }

        /// <summary>
        /// Virtual Start, must be called when subclassing
        /// </summary>
        protected virtual void Start() {
            _monoControllers.Start();
        }

        protected virtual void OnDrawGizmos() {
            if(!Initialized) {
                _monoControllers = new MonoControllers(this);
            }

            _monoControllers.OnDrawGizmos();
        }
    }
}