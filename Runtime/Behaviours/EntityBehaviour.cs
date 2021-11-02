
namespace BBUnity {

    /// <summary>
    /// The base entity behaviour. Entities give more control than a BaseBehaviour and enable 
    /// Controllers to use used as part of the component flow
    /// </summary>
    public class EntityBehaviour : BaseBehaviour {


        /// <summary>
        /// The 
        /// </summary>
        private EntityController[] _controllers;
        public EntityController[] Controllers {
            get { return _controllers ??= Utilities.FindReflectedFields<EntityController>(this); }
        }

        /*
         * Virtual Awake method which is called by Unity. Please note when overriden
         * 
         */ 
        protected virtual void Awake() {
            foreach(EntityController controller in Controllers) {
                controller.SetEntity(this);
                controller.Awake();
            }
        }

        /*
         * Virtual Start method which is called by Unity
         */ 
        protected virtual void Start() {
            foreach(EntityController controller in Controllers) {
                controller.Start();
            }
        }
    }
}