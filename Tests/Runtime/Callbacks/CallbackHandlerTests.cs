﻿using System;
using UnityEngine;
using NUnit.Framework;

using BBUnity;
using BBUnity.TestSupport;

namespace Callbacks {
    public class CallbackHandlerTests {

        public interface CallbackHandlerTestInterface {
            void ToCall();
        }

        public class CallbackHandlerTestComponent : MonoBehaviour, CallbackHandlerTestInterface {
            public void ToCall() {
                
            }
        }

        public class CallbackHandlerTestComponentBase : MonoBehaviour {

        }

        [Test]
        public void CallbackHandler_ShouldFindInterfaces() {
            TestUtilities.CreateThenDestroyGameObject(new Type[] { typeof(CallbackHandlerTestComponentBase), typeof(CallbackHandlerTestComponent) }, (GameObject obj) => {
                MonoBehaviour behaviour = obj.GetComponent<CallbackHandlerTestComponentBase>();
                CallbackHandler<CallbackHandlerTestInterface> callbackHandler = new CallbackHandler<CallbackHandlerTestInterface>(behaviour);

                Assert.AreEqual(1, callbackHandler.NumberOfCallbacks);
            });
        }

        [Test]
        public void CallbackHandler_ShouldFindMultipleInterfaces() {
            TestUtilities.CreateThenDestroyGameObject(new Type[] { typeof(CallbackHandlerTestComponentBase), typeof(CallbackHandlerTestComponent), typeof(CallbackHandlerTestComponent) }, (GameObject obj) => {
                MonoBehaviour behaviour = obj.GetComponent<CallbackHandlerTestComponentBase>();
                CallbackHandler<CallbackHandlerTestInterface> callbackHandler = new CallbackHandler<CallbackHandlerTestInterface>(behaviour);

                Assert.AreEqual(2, callbackHandler.NumberOfCallbacks);
            });
        }

        [Test]
        public void CallbackHandler_ShouldCallMultipleComponents() {
            TestUtilities.CreateThenDestroyGameObject(new Type[] { typeof(CallbackHandlerTestComponentBase), typeof(CallbackHandlerTestComponent), typeof(CallbackHandlerTestComponent) }, (GameObject obj) => {
                MonoBehaviour behaviour = obj.GetComponent<CallbackHandlerTestComponentBase>();
                CallbackHandler<CallbackHandlerTestInterface> callbackHandler = new CallbackHandler<CallbackHandlerTestInterface>(behaviour);

                int callCount = 0;
                callbackHandler.Call((CallbackHandlerTestInterface i) => {
                    callCount++;
                });

                Assert.AreEqual(2, callCount);
            });
        }

        [Test]
        public void CallbackHandler_ShouldAllowDisable() {
            TestUtilities.CreateThenDestroyGameObject(new Type[] { typeof(CallbackHandlerTestComponentBase), typeof(CallbackHandlerTestComponent), typeof(CallbackHandlerTestComponent) }, (GameObject obj) => {
                MonoBehaviour behaviour = obj.GetComponent<CallbackHandlerTestComponentBase>();
                CallbackHandler<CallbackHandlerTestInterface> callbackHandler = new CallbackHandler<CallbackHandlerTestInterface>(behaviour);

                callbackHandler.Disable();

                int callCount = 0;
                callbackHandler.Call((CallbackHandlerTestInterface i) => {
                    callCount++;
                });

                Assert.AreEqual(0, callCount);
            });
        }

        [Test]
        public void CallbackHandler_ShouldAllowEnable() {
            TestUtilities.CreateThenDestroyGameObject(new Type[] { typeof(CallbackHandlerTestComponentBase), typeof(CallbackHandlerTestComponent), typeof(CallbackHandlerTestComponent) }, (GameObject obj) => {
                MonoBehaviour behaviour = obj.GetComponent<CallbackHandlerTestComponentBase>();
                CallbackHandler<CallbackHandlerTestInterface> callbackHandler = new CallbackHandler<CallbackHandlerTestInterface>(behaviour);

                callbackHandler.Disable();

                BBAssert.IsCalled(0, (Action called) => {
                    callbackHandler.Call((CallbackHandlerTestInterface i) => {
                        called();
                    });
                });

                callbackHandler.Enable();

                BBAssert.IsCalled(2, (Action called) => {
                    callbackHandler.Call((CallbackHandlerTestInterface i) => {
                        called();
                    });
                });
            });
        }
    }
}
