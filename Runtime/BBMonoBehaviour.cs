using System.Collections;
using UnityEngine;

namespace BBUnity {

    /// <summary>
    /// An extended MonoBehaviour which provides access to a range of easier access / setters
    /// and helper methods to aid the use of Coroutines. Please note that no virtual calls
    /// to Awake, Update, OnGizmo are used in this class.
    /// </summary>
    [AddComponentMenu("")]
    public class BBMonoBehaviour : MonoBehaviour {

        /*
         * Provides slightly easier ways to access the underlying MonoBehaviour
         * propeties
         */
        public Transform Parent { get { return transform.parent; } set { transform.parent = value; } }
        public int Layer { get { return gameObject.layer; } set { gameObject.layer = value; } }
        public bool IsGameObjectActive { get { return gameObject.activeSelf; } set { gameObject.SetActive(value); } }
        public bool IsGameObjectInactive { get { return !gameObject.activeSelf; } }
        public bool IsEnabled { get { return enabled; } set { enabled = value; } }
        public bool IsDisabled { get { return !enabled; } }

        /*
         * Ease of use Setters
         */
        public void SetName(string name) { this.name = name; }
        public void ActivateGameObject() { gameObject.SetActive(true); }
        public void DeactivateGameObject() { gameObject.SetActive(false); }
        public void SetGameObjectActive(bool active) { gameObject.SetActive(active); }
        public void Enable() { enabled = true; }
        public void Disable() { enabled = false; }
        public void SetEnabled(bool enable) { enabled = enable; }
        public void SetParent(Transform parent) { transform.parent = parent; }
        public void SetLayer(int layer) { gameObject.layer = layer; }

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

        /// <summary>
        /// Resets the transformation with the option to skip the localScale
        /// </summary>
        /// <param name="resetScale"></param>
        public void ResetTransform(bool resetScale = true) {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;

            if(resetScale) {
                transform.localScale = Vector3.one;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="action"></param>
        public void WaitThen(float wait, System.Action action) {
            StartCoroutine(
                Wait(wait, action)
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="routine"></param>
        public void WaitThen(float wait, IEnumerator routine) {
            StartCoroutine(Wait(wait, () => {
                StartCoroutine(routine);
            }));
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


