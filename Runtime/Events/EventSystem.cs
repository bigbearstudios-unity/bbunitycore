using System;
using System.Collections.Generic;

namespace BBUnity.Events {

    /// <summary>
    /// A simple event system
    /// The events or event system should not be persisted into a file or database due to the
    /// nature of generation of the UUIDs
    /// </summary>
    public class EventSystem {
        public delegate void EventDelegate(Event e);

        private Dictionary<int, Dictionary<int, EventDelegate>> _events;

        public EventSystem() {
            _events = new Dictionary<int, Dictionary<int, EventDelegate>>();
        }

        public void Register<T>(EventDelegate onEvent) where T : Event {
            ListenFor<T>(onEvent);
        }

        public void Register(EventDelegate onEvent, Type eventType) {
            ListenFor(onEvent, eventType);
        }

        public void ListenFor<T>(EventDelegate onEvent) where T : Event {
            ListenFor(onEvent, typeof(T));
        }

        public void ListenFor(EventDelegate onEvent, Type eventType) {
            int eventHashCode = eventType.GetHashCode();
            int objectHashCode = onEvent.Target.GetHashCode();

            if(_events.TryGetValue(eventHashCode, out Dictionary<int, EventDelegate> events)) {
                events[objectHashCode] = onEvent; //TODO Should we warn of event overwrites?
            } else {
                _events[eventHashCode] = new Dictionary<int, EventDelegate>() { { objectHashCode, onEvent } };
            }
        }

        public void Broadcast(Event e) {
            int eventHashCode = e.GetType().GetHashCode();
            if(_events.TryGetValue(eventHashCode, out Dictionary<int, EventDelegate> value)) {
                foreach(EventDelegate del in value.Values) {
                    del(e);
                }
            }
        }

        public void Call(Event e) {
            Broadcast(e);
        }

        /// <summary>
        /// Removes the listener from all events. This is less efficent than removing a single event
        /// for a listener due to the iteration
        /// </summary>
        /// <param name="listener"></param>
        public void RemoveListener(object listener) {
            int objectHashCode = listener.GetHashCode();
            foreach(Dictionary<int, EventDelegate> events in _events.Values) {
                if(events.ContainsKey(objectHashCode)) {
                    events.Remove(objectHashCode);
                }
            }
        }

        
        public void RemoveListener<T>(object listener) where T : Event {
            RemoveListener(listener, typeof(T));
        }

        public void RemoveListener(object listener, Type eventType) {
            int objectHashCode = listener.GetHashCode();
            int eventHashCode = eventType.GetHashCode();

            if(_events.TryGetValue(eventHashCode, out Dictionary<int, EventDelegate> events)) {
                if(events.ContainsKey(objectHashCode)) {
                    events.Remove(objectHashCode);
                }
            }
        }

        /// <summary>
        /// Removes all of the listeners assigned to this EventSystem. This does a complete
        /// clear of the event system and if you are re-using the system you should use
        /// RemoveListeners(true);
        /// </summary>
        public void RemoveListeners() {
            _events.Clear();
        }

        public void RemoveListeners(bool preserveLookups) {
            if(preserveLookups) {
                foreach(Dictionary<int, EventDelegate> events in _events.Values) {
                    _events.Clear();
                }
            } else {
                RemoveListeners();
            }
        }

        public void RemoveListeners<T>() where T : Event {
            RemoveListeners(typeof(T));
        }

        /// <summary>
        /// Removes all of the listeners for a given Event type. This does a complete
        /// clear of the event system and if you are re-using the system you should use
        /// RemoveListeners(eventType, true);
        /// </summary>
        /// <param name="eventType"></param>
        public void RemoveListeners(Type eventType) {
            int eventHashCode = eventType.GetHashCode();
            if(_events.ContainsKey(eventHashCode)) {
                _events.Remove(eventHashCode);
            }
        }

        public void RemoveListeners<T>(bool preserveLookups) where T : Event {
            RemoveListeners(typeof(T), preserveLookups);
        }

        public void RemoveListeners(Type eventType, bool preserveLookups) {
            int eventHashCode = eventType.GetHashCode();
            if(_events.TryGetValue(eventHashCode, out Dictionary<int, EventDelegate> events)) {
                events.Clear();
            }
        }
    }
}