using NUnit.Framework;

using BBUnity.Events;
using System;

namespace Events {
    public class EventSystemTests {

        public class TestEventCaller {
            private bool called = false;

            public void CallEvent(Event e) {
                called = true;
            }

            public void AssertCalled() {
                Assert.IsTrue(called);
            }

            public void AssertNotCalled() {
                Assert.IsFalse(called);
            }
        }


        public class TestEvent : Event {

        }

        [Test]
        public void EventSystem_WhenRegisteredWithAnEventShouldCallbackWhenBroadcasted() {
            CreateEventSystem((EventSystem e) => {
                TestEventCaller caller = new TestEventCaller();
                e.Register<Event>(caller.CallEvent);
                e.Broadcast(new Event());

                caller.AssertCalled();
            });
        }

        [Test]
        public void EventSystem_WhenRegisteredWithAnEventShouldCallbackWhenCalled() {
            CreateEventSystem((EventSystem e) => {
                TestEventCaller caller = new TestEventCaller();
                e.Register<Event>(caller.CallEvent);
                e.Call(new Event());

                caller.AssertCalled();
            });
        }

        [Test]
        public void EventSystem_WhenRegisteringTwoEventsOnlyOneShouldBeCalled() {
            CreateEventSystem((EventSystem e) => {
                TestEventCaller caller = new TestEventCaller();
                e.Register<Event>(caller.CallEvent);

                TestEventCaller caller2 = new TestEventCaller();
                e.Register<TestEvent>(caller2.CallEvent);

                e.Call(new Event());

                caller.AssertCalled();
                caller2.AssertNotCalled();
            });
        }

        [Test]
        public void RemoveListeners_ShouldRemoveAllListeners() {
            CreateEventSystem((EventSystem e) => {
                TestEventCaller caller = new TestEventCaller();
                e.Register<Event>(caller.CallEvent);
                e.RemoveListeners();

                e.Call(new Event());

                caller.AssertNotCalled();
            });
        }

        [Test]
        public void RemoveListeners_ShouldRemoveAllListeners_ForAGivenEvent() {
            CreateEventSystem((EventSystem e) => {
                TestEventCaller caller = new TestEventCaller();
                e.Register<Event>(caller.CallEvent);
                e.RemoveListeners<Event>();

                TestEventCaller caller2 = new TestEventCaller();
                e.Register<TestEvent>(caller2.CallEvent);

                e.Call(new Event());
                e.Call(new TestEvent());

                caller.AssertNotCalled();
                caller2.AssertCalled();
            });
        }

        [Test]
        public void RemoveListener_ShouldRemoveListenerForObject() {
            CreateEventSystem((EventSystem e) => {
                TestEventCaller caller = new TestEventCaller();
                e.Register<Event>(caller.CallEvent);
                e.RemoveListener(caller);

                e.Call(new Event());

                caller.AssertNotCalled();
            });
        }

        [Test]
        public void RemoveListener_ShouldRemoveListenerForEvent() {
            CreateEventSystem((EventSystem e) => {
                TestEventCaller caller = new TestEventCaller();
                e.Register<Event>(caller.CallEvent);
                e.RemoveListener<Event>(caller);

                e.Call(new Event());

                caller.AssertNotCalled();
            });
        }

        [Test]
        public void RemoveListener_ShouldRemoveListenerForObject_ButLeaveOtherListener() {
            CreateEventSystem((EventSystem e) => {
                TestEventCaller caller = new TestEventCaller();
                e.Register<Event>(caller.CallEvent);
                e.RemoveListener<Event>(caller);

                TestEventCaller caller2 = new TestEventCaller();
                e.Register<Event>(caller2.CallEvent);

                e.Call(new Event());

                caller.AssertNotCalled();
                caller2.AssertCalled();
            });
        }

        private void CreateEventSystem(Action<EventSystem> func) {
            EventSystem eventSystem = new EventSystem();
            func(eventSystem);
        }
    }
}
