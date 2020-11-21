using System;
using UnityEngine;

namespace BBUnity {

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BehaviourDelegate<T> {

        /// <summary>
        /// Multiple callbacks to process
        /// </summary>
        protected T[] _delegates;

        /// <summary>
        /// Is the callback handler enabled
        /// </summary>
        private bool _enabled = true;

        /// <summary>
        /// The number of callbacks currently registered
        /// </summary>
        public int NumberOfDelegates {
            get { return _delegates.Length; }
        }

        /// <summary>
        /// Creates an empty deletes array
        /// </summary>
        public BehaviourDelegate() {
            _delegates = new T[0];
        }

        /// <summary>
        /// Finds all references to T in the current behaviour, stores them as callbacks
        /// </summary>
        /// <param name="behaviour"></param>
        public BehaviourDelegate(MonoBehaviour behaviour) {
            _delegates = behaviour.GetComponents<T>();
        }

        /// <summary>
        /// Disables all callbacks
        /// </summary>
        public void Disable() {
            _enabled = false;
        }

        /// <summary>
        /// Enables all callbacks if they are disabled
        /// </summary>
        public void Enable() {
            _enabled = true;
        }

        public void AddDelegate(T del) {
            ArrayUtilities.Append(ref _delegates, del);
        }

        /// <summary>
        /// Allows the calling of a method on all of the callbacks registered
        /// </summary>
        /// <param name="action"></param>
        public void Process(Action<T> action) {
            if(_enabled) {
                foreach(T del in _delegates) {
                    if(del != null) {
                        action(del);
                    }
                }
            }
        }
    }
}

