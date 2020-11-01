# CallbackHandler

CallbackHandler allows the calling of callbacks using a given action.

Allows the handling of callbacks to a given handler via a MonoBehaviour object

``` csharp
using BBUnity;

class MyCallbackClass : MonoBehaviour {

    private CallbackHandler<ICallback> _callbackHandler;

    private void Awake() {
        //Finds all instances of ICallback within the attached
        //GameObject
        _callbackHandler = new CallbackHandler(this);
    }

    private void Call() {
        _callbackHandler.Call(OnCallback);
    }

    private void OnCallback(ICallback callback) {
        //Use ICallback as required
    }
}

```

Or you can use it via Scene Instances

``` csharp
using BBUnity;

class MyGlobalCallbackClass : MonoBehaviour {
    private CallbackHandler<ICallback> _callbackHandler;

    private void Awake() {
        //Find all ICallback in the Scene
        _callbackHandler = new CallbackHandler();
    }
}

```