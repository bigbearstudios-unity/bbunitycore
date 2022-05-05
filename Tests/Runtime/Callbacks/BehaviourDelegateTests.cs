using System;
using UnityEngine;
using NUnit.Framework;

using BBUnity;
using BBUnity.TestSupport;

namespace Callbacks {
    public class BehaviourDelegateTests {

        public interface ICallbackHandlerTestInterface {
            void ToCall();
        }

        public class CallbackHandlerTestComponent : MonoBehaviour, ICallbackHandlerTestInterface {
            public void ToCall() {
                
            }
        }

        public class CallbackHandlerTestComponentBase : MonoBehaviour {

        }

        [Test]
        public void CallbackHandler_ShouldFindInterfaces() {
            TestUtilities.CreateThenDestroyGameObject(new Type[] { typeof(CallbackHandlerTestComponentBase), typeof(CallbackHandlerTestComponent) }, (GameObject obj) => {
                MonoBehaviour behaviour = obj.GetComponent<CallbackHandlerTestComponentBase>();
                BehaviourDelegate<ICallbackHandlerTestInterface> callbackHandler = new BehaviourDelegate<ICallbackHandlerTestInterface>(behaviour);

                Assert.AreEqual(1, callbackHandler.NumberOfDelegates);
            });
        }

        [Test]
        public void CallbackHandler_ShouldFindMultipleInterfaces() {
            TestUtilities.CreateThenDestroyGameObject(new Type[] { typeof(CallbackHandlerTestComponentBase), typeof(CallbackHandlerTestComponent), typeof(CallbackHandlerTestComponent) }, (GameObject obj) => {
                MonoBehaviour behaviour = obj.GetComponent<CallbackHandlerTestComponentBase>();
                BehaviourDelegate<ICallbackHandlerTestInterface> callbackHandler = new BehaviourDelegate<ICallbackHandlerTestInterface>(behaviour);

                Assert.AreEqual(2, callbackHandler.NumberOfDelegates);
            });
        }

        [Test]
        public void CallbackHandler_ShouldProcessMultipleComponents() {
            TestUtilities.CreateThenDestroyGameObject(new Type[] { typeof(CallbackHandlerTestComponentBase), typeof(CallbackHandlerTestComponent), typeof(CallbackHandlerTestComponent) }, (GameObject obj) => {
                MonoBehaviour behaviour = obj.GetComponent<CallbackHandlerTestComponentBase>();
                BehaviourDelegate<ICallbackHandlerTestInterface> callbackHandler = new BehaviourDelegate<ICallbackHandlerTestInterface>(behaviour);

                int callCount = 0;
                callbackHandler.Process((ICallbackHandlerTestInterface i) => {
                    callCount++;
                });

                Assert.AreEqual(2, callCount);
            });
        }

        [Test]
        public void CallbackHandler_ShouldAllowDisable() {
            TestUtilities.CreateThenDestroyGameObject(new Type[] { typeof(CallbackHandlerTestComponentBase), typeof(CallbackHandlerTestComponent), typeof(CallbackHandlerTestComponent) }, (GameObject obj) => {
                MonoBehaviour behaviour = obj.GetComponent<CallbackHandlerTestComponentBase>();
                BehaviourDelegate<ICallbackHandlerTestInterface> callbackHandler = new BehaviourDelegate<ICallbackHandlerTestInterface>(behaviour);

                callbackHandler.Disable();

                int callCount = 0;
                callbackHandler.Process((ICallbackHandlerTestInterface i) => {
                    callCount++;
                });

                Assert.AreEqual(0, callCount);
            });
        }

        [Test]
        public void CallbackHandler_ShouldAllowEnable() {
            TestUtilities.CreateThenDestroyGameObject(new Type[] { typeof(CallbackHandlerTestComponentBase), typeof(CallbackHandlerTestComponent), typeof(CallbackHandlerTestComponent) }, (GameObject obj) => {
                MonoBehaviour behaviour = obj.GetComponent<CallbackHandlerTestComponentBase>();
                BehaviourDelegate<ICallbackHandlerTestInterface> callbackHandler = new BehaviourDelegate<ICallbackHandlerTestInterface>(behaviour);

                callbackHandler.Disable();

                UnityAssert.IsCalled(0, (Action called) => {
                    callbackHandler.Process((ICallbackHandlerTestInterface i) => {
                        called();
                    });
                });

                callbackHandler.Enable();

                UnityAssert.IsCalled(2, (Action called) => {
                    callbackHandler.Process((ICallbackHandlerTestInterface i) => {
                        called();
                    });
                });
            });
        }
    }
}
