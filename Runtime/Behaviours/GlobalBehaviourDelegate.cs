using UnityEngine;

namespace BBUnity {
    public class GlobalBehaviourDelegate<T> : BehaviourDelegate<T> {

        public GlobalBehaviourDelegate() {
            _delegates = Utilities.FindAllInstancesInActiveScene<T>(false);
        }

        public GlobalBehaviourDelegate(bool includeInactive) {
            _delegates = Utilities.FindAllInstancesInActiveScene<T>(includeInactive);
        }
    }
}


