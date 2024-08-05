using System.Collections;
using UnityEngine;

namespace BBUnity {

    /// <summary>
    /// An extended MonoBehaviour which provides access to a range of easier access / setters
    /// and helper methods to aid the use of Coroutines. Please note that no virtual calls
    /// to Awake, Update, OnGizmo are used in this class and can be used as normal by 
    /// subclasses
    /// </summary>
    [AddComponentMenu("")]
    public class BBMonoBehaviour : MonoBehaviour {

        /*
         * Provides slightly easier ways to access the underlying MonoBehaviour
         * propeties
         */
        public bool Active { get { return gameObject.activeSelf; } set { gameObject.SetActive(value); } }
        public bool Enabled { get { return enabled; } set { enabled = value; } }

        /*
         * Ease of use Setters
         */
        public void SetName(string name) { this.name = name; }
        public void Activate() { gameObject.SetActive(true); }
        public void Deactivate() { gameObject.SetActive(false); }
        public void SetActive(bool active) { gameObject.SetActive(active); }
        public void Enable() { enabled = true; }
        public void Disable() { enabled = false; }
        public void SetEnabled(bool enable) { enabled = enable; }

        /// <summary>
        /// Resets the entire transformation with the following:
        /// position = Vector3.zero
        /// rotation = Quaternion.identity;
        /// localScale = Vector3.one;
        /// </summary>
        public void ResetTransform() {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public void ResetTransformIgnoreScale() {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="action"></param>
        public void WaitThen(float wait, System.Action action) {
            StartCoroutine(Wait(wait, action));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="routine"></param>
        public void WaitThen(float wait, IEnumerator routine) {
            StartCoroutine(Wait(wait, () => { StartCoroutine(routine); }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private IEnumerator Wait(float wait, System.Action action) {
            yield return new WaitForSeconds(wait);

            action.Invoke();
        }
    }
}

// TODO
// Move this into some sort of scene management
// public static T[] FindAllInstancesInActiveScene<T>(bool includeInactive = false) {
//             List<T> toReturn = new List<T>();
//             Scene scene = SceneManager.GetActiveScene();
//             GameObject[] gameObjects = scene.GetRootGameObjects();

//             if(includeInactive) {
//                 foreach(GameObject gameObject in gameObjects) {
//                     T[] instances = gameObject.GetComponentsInChildren<T>(includeInactive);
//                     foreach(T instance in instances) {
//                         toReturn.Add(instance);
//                     }
//                 }
//             } else {
//                 foreach(GameObject gameObject in gameObjects) {
//                     if(gameObject.activeSelf) {
//                         T[] instances = gameObject.GetComponentsInChildren<T>();
//                         foreach(T instance in instances) {
//                             toReturn.Add(instance);
//                         }
//                     }
//                 }
//             }

//             return toReturn.ToArray();
//         }

// TODO 
// public static T[] FindReflectedFields<T>(object obj) {
//     System.Reflection.BindingFlags bindingFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
//     System.Reflection.FieldInfo[] fields = obj.GetType().GetFields(bindingFlags);

//     List<T> toReturn = new List<T>();
//     foreach(System.Reflection.FieldInfo field in fields) {
//         if(field.FieldType.IsSubclassOf(typeof(T))){
//             toReturn.Add((T)field.GetValue(obj));
//         }
//     }

//     return toReturn.ToArray();
// }