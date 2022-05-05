using UnityEngine;

namespace BBUnity {

    /// <summary>
    /// Allows the handling of global Interfaces from a single handler
    /// </summary>
    /// <typeparam name="T">The type of Interface being delegated too</typeparam>
    public class GlobalBehaviourDelegate<T> : BehaviourDelegate<T> {

        public GlobalBehaviourDelegate() {
            _delegates = Utilities.FindAllInstancesInActiveScene<T>(false);
        }

        public GlobalBehaviourDelegate(bool includeInactive) {
            _delegates = Utilities.FindAllInstancesInActiveScene<T>(includeInactive);
        }
    }
}


