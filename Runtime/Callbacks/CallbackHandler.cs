using System;
using UnityEngine;

namespace BBUnity {
    public class CallbackHandler<T> {

        /// <summary>
        /// Multiple callbacks to process
        /// </summary>
        private T[] _callbacks;

        /// <summary>
        /// Is the callback handler enabled
        /// </summary>
        private bool _enabled = true;

        public int NumberOfCallbacks {
            get { return _callbacks.Length; }
        }

        /// <summary>
        /// Finds all references to T in the current behaviour, stores them as callbacks
        /// </summary>
        /// <param name="behaviour"></param>
        public CallbackHandler(MonoBehaviour behaviour) {
            _callbacks = behaviour.GetComponents<T>();
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

        public void AddCallback(T callback) {
            ArrayUtilities.Append(ref _callbacks, callback);
        }

        /// <summary>
        /// Allows the calling of a method on all of the callbacks registered
        /// </summary>
        /// <param name="action"></param>
        public void Process(Action<T> action) {
            if(_enabled) {
                foreach(T callback in _callbacks) {
                    if(callback != null) {
                        action(callback);
                    }
                }
            }
        }
    }
}