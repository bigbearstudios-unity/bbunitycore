using System;
using UnityEngine;
using NUnit.Framework;

using BBUnity;
using BBUnity.TestSupport;

namespace Callbacks {
    public class GlobalBehaviourDelegateTests {

        public interface IGlobalCallbackInterface {
            void ToCall();
        }

        public class IGlobalCallbackInterfaceComponent : MonoBehaviour, IGlobalCallbackInterface {
            public void ToCall() {}
        }

        [Test]
        public void CallbackHandler_ShouldFindAllGlobalInterfaces() {
            TestUtilities.CreateThenDestroyGameObject<IGlobalCallbackInterfaceComponent>((IGlobalCallbackInterfaceComponent obj) => {
                TestUtilities.CreateThenDestroyGameObject<IGlobalCallbackInterfaceComponent>((IGlobalCallbackInterfaceComponent obj2) => {
                    GlobalBehaviourDelegate<IGlobalCallbackInterface> handler = new GlobalBehaviourDelegate<IGlobalCallbackInterface>();
                    Assert.AreEqual(2, handler.NumberOfDelegates);
                });
            });
        }

        [Test]
        public void CallbackHandler_ShouldntFindInactiveInterfaces() {
            TestUtilities.CreateThenDestroyGameObject<IGlobalCallbackInterfaceComponent>((IGlobalCallbackInterfaceComponent obj) => {
                obj.gameObject.SetActive(false);

                TestUtilities.CreateThenDestroyGameObject<IGlobalCallbackInterfaceComponent>((IGlobalCallbackInterfaceComponent obj2) => {
                    GlobalBehaviourDelegate<IGlobalCallbackInterface> handler = new GlobalBehaviourDelegate<IGlobalCallbackInterface>();
                    Assert.AreEqual(1, handler.NumberOfDelegates);
                });
            });
        }
    }
}
