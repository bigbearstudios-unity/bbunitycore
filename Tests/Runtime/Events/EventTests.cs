using NUnit.Framework;

using BBUnity.Events;

namespace Events {
    public class EventTests {

        [Test]
        public void Event_ShouldAllowConstructionWithACaller() {
            Event e = new Event(5);
            Assert.AreEqual(5, e.Caller);
        }

        [Test]
        public void Event_ShouldAllowConstructionWithACallerAndData() {
            Event e = new Event(5, 10);
            Assert.AreEqual(10, e.Data);
        }

        [Test]
        public void HasCaller_ShouldReturnFalseWithNoCaller() {
            Assert.IsFalse(new Event().HasCaller);
        }

        [Test]
        public void HasCaller_ShouldReturnTrueWithACaller() {
            Event e = new Event(10);
            Assert.IsTrue(e.HasCaller);
        }

        [Test]
        public void HasData_ShouldReturnFalseWithNoData() {
            Assert.IsFalse(new Event().HasData);
        }

        [Test]
        public void HasData_ShouldReturnTrueWithData() {
            Assert.IsTrue(new Event(null, 10).HasData);
        }
    }
}