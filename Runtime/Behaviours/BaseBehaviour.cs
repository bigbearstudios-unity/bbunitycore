using System.Collections;
using UnityEngine;

namespace BBUnity {

    /// <summary>
    /// The base behaviour for all components in BBUnity. This provides easy access methods for basic Unity
    /// properties
    /// </summary>
    [AddComponentMenu("")]
    public class BaseBehaviour : MonoBehaviour {

        /*
         * Ease of use Properties
         */
        public string Name { get { return name; } set { Name = value; } }
        public Transform Parent { get { return transform.parent; } set { transform.parent = value; } }
        public bool GameObjectActive { get { return gameObject.activeSelf; } set { gameObject.SetActive(value); } }
        public bool GameObjectInactive { get { return !gameObject.activeSelf; } }
        public bool Enabled { get { return enabled; } set { enabled = value; } }
        public bool Disabled { get { return !enabled; } }
        public int Layer { get { return gameObject.layer; } set { gameObject.layer = value; } }

        /*
         * Ease of use Setters
         */
        public void SetName(string name) { this.name = name; }
        public void ActivateGameObject() { gameObject.SetActive(true); }
        public void DeactivateGameObject() { gameObject.SetActive(false); }
        public void SetActiveGameObject(bool active) { gameObject.SetActive(active); }
        public void Enable() { enabled = true; }
        public void Disable() { enabled = false; }
        public void SetEnabled(bool enable) { enabled = enable; }
        public void SetParent(Transform parent) { transform.parent = parent; }
        public void SetLayer(int layer) { gameObject.layer = layer; }

        /// <summary>
        /// Resets the entire transformation with the following
        /// position = Vector3.zero
        /// rotation = Quaternion.identity;
        /// localScale = Vector3.one;
        /// </summary>
        public void ResetTransform() {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public void ResetTransform(bool resetScale = true) {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;

            if(resetScale) {
                transform.localScale = Vector3.one;
            }
        }

        /// <summary>
        /// Waits a given time in seconds and then calls the action provided
        /// </summary>
        public void WaitThen(float wait, System.Action action) {
            StartCoroutine(Wait(wait, action));
        }

        public void WaitThen(float wait, IEnumerator routine) {
            StartCoroutine(Wait(wait, () => {
                StartCoroutine(routine);
            }));
        }

        private IEnumerator Wait(float wait, System.Action action) {
            yield return new WaitForSeconds(wait);

            action();
        }
    }
}


