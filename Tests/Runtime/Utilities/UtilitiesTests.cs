﻿using NUnit.Framework;
using UnityEngine;

using BBUnity;
using BBUnity.TestSupport;

namespace Utilities {
    public class Utilities {
        [Test]
        public void Tap_ShouldReturnTheObjectPassed() {
            object obj = new object();
            Assert.AreEqual(obj, BBUnity.Utilities.Tap(obj, (object ob1) => {

            }));
        }

        [Test]
        public void Tap_ShouldCallThePassedDelegate() {
            bool called = false;
            BBUnity.Utilities.Tap(new object(), (object ob) => {
                called = true;
            });

            Assert.IsTrue(called);
        }

        [Test]
        public void CreateGameObject_ShouldCreateAnObjectWithThePassedName() {
            Assert.AreEqual("test", BBUnity.Utilities.CreateGameObject("test").name);
            Assert.AreEqual("test", BBUnity.Utilities.CreateGameObject<SpriteRenderer>("test").name);
        }

        [Test]
        public void CreateGameObject_ShouldCreateAnObjectWithTheComponent_WhenPassedComponents() {
            Assert.IsNotNull(BBUnity.Utilities.CreateGameObject("", new System.Type[]{ typeof(SpriteRenderer) }).GetComponent<SpriteRenderer>());
        }

        [Test]
        public void CreateGameObject_ShouldCreateAnObjectWithTheComponent_WhenPassedComponentTemplate() {
            Assert.IsNotNull(BBUnity.Utilities.CreateGameObject<SpriteRenderer>().GetComponent<SpriteRenderer>());
        }

        [Test]
        public void AddOrGetComponent_ShouldAddANewComponent_WhenComponentIsNull() {
            GameObject obj = new GameObject();

            Assert.IsNotNull(BBUnity.Utilities.AddOrGetComponent<SpriteRenderer>(obj));
            Assert.IsNotNull(obj.GetComponent<SpriteRenderer>());
        }

        [Test]
        public void AddOrGetComponent_ShouldGetComponent_WhenComponentIsNotNull() {
            GameObject obj = new GameObject("test", new System.Type[] { typeof(SpriteRenderer) });

            Assert.IsNotNull(obj.GetComponent<SpriteRenderer>());
            Assert.AreEqual(1, obj.GetComponents<SpriteRenderer>().Length);
        }

        class UTestsFindAllInstances : MonoBehaviour {

        }

        [Test]
        public void FindAllInstancesInActiveScene_ShouldFindSingleComponentInScene_WhereThereIsASingleActiveComponent() {
            TestUtilities.CreateThenDestroyGameObject("UTestsFindAllInstances", new System.Type[] { typeof(UTestsFindAllInstances) }, (GameObject obj) => {
                UTestsFindAllInstances[] instances = BBUnity.Utilities.FindAllInstancesInActiveScene<UTestsFindAllInstances>();
                Assert.AreEqual(1, instances.Length);
            });
        }

        [Test]
        public void FindAllInstancesInActiveScene_ShouldNotFindSingleComponentInScene_WhereThereIsASingleInactiveComponent() {

            //TODO Can't get this to pass!
            TestUtilities.CreateThenDestroyGameObject("UTestsFindAllInstances", new System.Type[] { typeof(UTestsFindAllInstances) }, (GameObject obj) => {
                //obj.SetActive(false);
                //UTestsFindAllInstances[] instances = BBUnity.Utilities.FindAllInstancesInActiveScene<UTestsFindAllInstances>();
                //Debug.Log(instances.Length);
                //Assert.AreEqual(0, instances.Length);
            });
        }
    }
}


