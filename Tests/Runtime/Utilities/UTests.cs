﻿using NUnit.Framework;
using UnityEngine;

namespace Utilities {
    public class UTests {

        [Test]
        public void Tap_ShouldReturnTheObjectPassed() {
            object ob = new object();
            Assert.AreEqual(ob, U.Tap(ob, (object ob1) => {

            }));
        }

        [Test]
        public void Tap_ShouldCallThePassedDelegate() {
            bool called = false;
            U.Tap(new object(), (object ob) => {
                called = true;
            });

            Assert.IsTrue(called);
        }

        [Test]
        public void CreateGameObject_ShouldCreateAnObjectWithThePassedName() {
            Assert.AreEqual("test", U.CreateGameObject("test").name);
            Assert.AreEqual("test", U.CreateGameObject<SpriteRenderer>("test").name);
        }

        [Test]
        public void CreateGameObject_ShouldCreateAnObjectWithTheComponent_WhenPassedComponents() {
            Assert.IsNotNull(U.CreateGameObject("", new System.Type[]{ typeof(SpriteRenderer) }).GetComponent<SpriteRenderer>());
        }

        [Test]
        public void CreateGameObject_ShouldCreateAnObjectWithTheComponent_WhenPassedComponentTemplate() {
            Assert.IsNotNull(U.CreateGameObject<SpriteRenderer>().GetComponent<SpriteRenderer>());
        }

        [Test]
        public void AddOrGetComponent_ShouldAddANewComponent_WhenComponentIsNull() {
            GameObject obj = new GameObject();

            Assert.IsNotNull(U.AddOrGetComponent<SpriteRenderer>(obj));
            Assert.IsNotNull(obj.GetComponent<SpriteRenderer>());
        }

        [Test]
        public void AddOrGetComponent_ShouldGetComponent_WhenComponentIsNotNull() {
            GameObject obj = new GameObject("test", new System.Type[] { typeof(SpriteRenderer) });

            Assert.IsNotNull(obj.GetComponent<SpriteRenderer>());
            Assert.AreEqual(1, obj.GetComponents<SpriteRenderer>().Length);
        }
    }
}


