using NUnit.Framework;

using BBUnity;
using BBUnity.TestSupport;
using UnityEngine;
using NUnit.Framework.Constraints;

namespace Behaviours {
    public class BaseBehaviourTest {

        /*
         * Get Tests
         */

        [Test]
        public void Position_ShouldReturnTransformsPosition() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            BBAssert.AreEqual(behaviour.Position, behaviour.transform.position);
        }

        [Test]
        public void Parent_ShouldReturnTransformsParent() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            Assert.AreEqual(behaviour.Parent, behaviour.transform.parent);
        }

        [Test]
        public void Layer_ShouldReturnGameObjectLayer() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            Assert.AreEqual(behaviour.Layer, behaviour.gameObject.layer);
        }

        [Test]
        public void LocalPosition_ShouldReturnTransformsLocalPosition() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            Assert.AreEqual(behaviour.LocalPosition, behaviour.transform.localPosition);
        }

        [Test]
        public void Rotation_ShouldReturnTransformsRotation() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            BBAssert.AreEqual(behaviour.Rotation, behaviour.transform.rotation);
        }

        [Test]
        public void LocalScale_ShouldReturnTransformsLocalScale() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            BBAssert.AreEqual(behaviour.LocalScale, behaviour.transform.localScale);
        }

        [Test]
        public void LossyScale_ShouldReturnTransformsLossyScale() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            BBAssert.AreEqual(behaviour.LossyScale, behaviour.transform.lossyScale);
        }

        [Test]
        public void Active_ShouldReturnGameObjectActiveSelf() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            Assert.AreEqual(behaviour.Active, behaviour.gameObject.activeSelf);
        }

        [Test]
        public void Enabled_ShouldReturnUnityEnabled() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            Assert.AreEqual(behaviour.Enabled, behaviour.enabled);
        }

        /*
         * Set Tests 
         */

         [Test]
        public void SetPosition_ShouldSetTranformsPosition() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            behaviour.Position = Vector3.up;
            behaviour.SetPosition(Vector3.up);

            BBAssert.AreEqual(behaviour.transform.position, Vector3.up);
        }

        [Test]
        public void SetLocalScale_ShouldSetTranformsLocalScale() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            behaviour.LocalScale = Vector3.up;
            behaviour.SetLocalScale(Vector3.up);

            Assert.AreEqual(behaviour.transform.localScale, Vector3.up);
        }

        [Test]
        public void SetLocalPosition_ShouldSetTransformsLocalPosition() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            behaviour.LocalPosition = Vector3.up;
            behaviour.SetLocalPosition(Vector3.up);

            Assert.AreEqual(behaviour.transform.localPosition, Vector3.up);
        }

        [Test]
        public void SetActive_ShouldSetGameObjectsActiveSelf() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            behaviour.Active = false;
            behaviour.SetActive(false);

            Assert.AreEqual(behaviour.gameObject.activeSelf, false);
        }

        [Test]
        public void SetEnabled_ShouldSetUnityEnabled() {
            BaseBehaviour behaviour = TestUtilities.CreateGameObject<BaseBehaviour>();
            behaviour.Enabled = false;
            behaviour.SetEnabled(false);

            Assert.AreEqual(behaviour.enabled, false);
        }
    }

}

