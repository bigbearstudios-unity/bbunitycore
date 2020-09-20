using System.Collections.Generic;

namespace BBUnity.Events {

    public class Event {

        /// <summary>
        /// The caller of the event
        /// </summary>
        protected object _caller;

        /// <summary>
        /// The data which is associated with the event
        /// </summary>
        protected object _data;

        public object Caller { get { return _caller; } }
        public bool HasCaller { get { return Caller != null; } }

        public object Data { get { return _data; } }
        public bool HasData { get { return _data != null; } }

        public Event() {
            _caller = null;
            _data = null;
        }

        public Event(object caller) {
            _caller = caller;
            _data = null;
        }

        public Event(object caller, object data) {
            _caller = caller;
            _data = data;
        }
    }
}