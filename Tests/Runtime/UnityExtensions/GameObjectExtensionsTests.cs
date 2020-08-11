using NUnit.Framework;
using UnityEngine;

using BBUnity;

namespace UnityExtensions {
    public class GameObjectExtensionsTest {

        [Test]
        public void AddOrGetComponent_ShouldAddANewComponent_WhenComponentIsNull() {
            GameObject obj = new GameObject();

            Assert.IsNotNull(obj.AddOrGetComponent<SpriteRenderer>());
            Assert.IsNotNull(obj.GetComponent<SpriteRenderer>());
        }

        [Test]
        public void AddOrGetComponent_ShouldGetComponent_WhenComponentIsNotNull() {
            GameObject obj = new GameObject("test", new System.Type[] { typeof(SpriteRenderer) });

           Assert.IsNotNull(obj.GetComponent<SpriteRenderer>());
           Assert.IsNotNull(obj.AddOrGetComponent<SpriteRenderer>());
           Assert.AreEqual(1, obj.GetComponents<SpriteRenderer>().Length);
        }
    }
}

