using System;
using UnityEngine;

using static BBUnity.Events.EventSystem;

namespace BBUnity.Events {
    public static class GlobalEventSystem {

        private static EventSystem __globalEventSystem;

        static GlobalEventSystem() {
            __globalEventSystem = new EventSystem();
        }

        public static void Register<T>(EventDelegate onEvent) where T : Event {
            __globalEventSystem.Register<T>(onEvent);
        }

        public static void Register(EventDelegate onEvent, Type eventType) {
            __globalEventSystem.Register(onEvent, eventType);
        }

        public static void ListenFor<T>(EventDelegate onEvent) where T : Event {
            __globalEventSystem.ListenFor<T>(onEvent);
        }

        public static void ListenFor(EventDelegate onEvent, Type eventType) {
            __globalEventSystem.ListenFor(onEvent, eventType);
        }

        public static void Broadcast(Event e) {
            __globalEventSystem.Broadcast(e);
        }

        public static void Call(Event e) {
            __globalEventSystem.Call(e);
        }

        public static void RemoveListener(object listener) {
            __globalEventSystem.RemoveListener(listener);
        }

        public static void RemoveListener<T>(object listener) where T : Event {
            __globalEventSystem.RemoveListener<T>(listener);
        }

        public static void RemoveListener(object listener, Type eventType) {
            __globalEventSystem.RemoveListener(listener, eventType);
        }

        public static void RemoveListeners() {
            __globalEventSystem.RemoveListeners();
        }

        public static void RemoveListeners(bool preserveLookups) {
            __globalEventSystem.RemoveListeners(preserveLookups);
        }

        public static void RemoveListeners<T>() where T : Event {
            __globalEventSystem.RemoveListeners<T>();
        }

        public static void RemoveListeners(Type eventType) {
            __globalEventSystem.RemoveListeners(eventType);
        }

        public static void RemoveListeners<T>(bool preserveLookups) where T : Event {
           __globalEventSystem.RemoveListeners<T>(preserveLookups);
        }

        public static void RemoveListeners(Type eventType, bool preserveLookups) {
            __globalEventSystem.RemoveListeners(eventType, preserveLookups);
        }
    }
}

