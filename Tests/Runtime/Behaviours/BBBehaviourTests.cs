﻿using NUnit.Framework;

using BBUnity;
using BBUnity.TestSupport;
using UnityEngine;
using NUnit.Framework.Constraints;

namespace Behaviours {
    public class BBBehaviourTest {

        /*
         * Get Tests
         */

        [Test]
        public void Position_ShouldReturnTransformsPosition() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            UnityAssert.AreEqual(behaviour.Position, behaviour.transform.position);
        }

        [Test]
        public void Parent_ShouldReturnTransformsParent() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            Assert.AreEqual(behaviour.Parent, behaviour.transform.parent);
        }

        [Test]
        public void Layer_ShouldReturnGameObjectLayer() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            Assert.AreEqual(behaviour.Layer, behaviour.gameObject.layer);
        }

        [Test]
        public void LocalPosition_ShouldReturnTransformsLocalPosition() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            Assert.AreEqual(behaviour.LocalPosition, behaviour.transform.localPosition);
        }

        [Test]
        public void Rotation_ShouldReturnTransformsRotation() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            UnityAssert.AreEqual(behaviour.Rotation, behaviour.transform.rotation);
        }

        [Test]
        public void LocalScale_ShouldReturnTransformsLocalScale() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            UnityAssert.AreEqual(behaviour.LocalScale, behaviour.transform.localScale);
        }

        [Test]
        public void LossyScale_ShouldReturnTransformsLossyScale() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            UnityAssert.AreEqual(behaviour.LossyScale, behaviour.transform.lossyScale);
        }

        [Test]
        public void Active_ShouldReturnGameObjectActiveSelf() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            Assert.AreEqual(behaviour.Active, behaviour.gameObject.activeSelf);
        }

        [Test]
        public void Enabled_ShouldReturnUnityEnabled() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            Assert.AreEqual(behaviour.Enabled, behaviour.enabled);
        }

        /*
         * Set Tests 
         */

         [Test]
        public void SetPosition_ShouldSetTranformsPosition() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            behaviour.Position = Vector3.up;
            behaviour.SetPosition(Vector3.up);

            UnityAssert.AreEqual(behaviour.transform.position, Vector3.up);
        }

        [Test]
        public void SetLocalScale_ShouldSetTranformsLocalScale() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            behaviour.LocalScale = Vector3.up;
            behaviour.SetLocalScale(Vector3.up);

            Assert.AreEqual(behaviour.transform.localScale, Vector3.up);
        }

        [Test]
        public void SetLocalPosition_ShouldSetTransformsLocalPosition() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            behaviour.LocalPosition = Vector3.up;
            behaviour.SetLocalPosition(Vector3.up);

            Assert.AreEqual(behaviour.transform.localPosition, Vector3.up);
        }

        [Test]
        public void SetActive_ShouldSetGameObjectsActiveSelf() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            behaviour.Active = false;
            behaviour.SetActive(false);

            Assert.AreEqual(behaviour.gameObject.activeSelf, false);
        }

        [Test]
        public void SetEnabled_ShouldSetUnityEnabled() {
            BBBehaviour behaviour = U.CreateGameObject<BBBehaviour>();
            behaviour.Enabled = false;
            behaviour.SetEnabled(false);

            Assert.AreEqual(behaviour.enabled, false);
        }
    }

}

