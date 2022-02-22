using System.Collections;
using UnityEngine;

namespace BBUnity {

    /// <summary>
    /// The base behaviour for all components in BBUnity. This provides easy access methods for basic Unity
    /// properties
    /// </summary>
    public class BaseBehaviour : MonoBehaviour {

        public string Name {
            get { return name; }
            set { Name = value; }
        }

        public Vector3 Position {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public Transform Parent {
            get { return transform.parent; }
            set { transform.parent = value; }
        }

        public int Layer {
            get { return gameObject.layer; }
            set { gameObject.layer = value; }
        }

        public Vector3 LocalPosition {
            get { return transform.localPosition; }
            set { transform.localPosition = value; }
        }

        public Quaternion Rotation {
            get { return transform.rotation; }
            set { transform.rotation = value; }
        }

        public Vector3 LocalScale {
            get { return transform.localScale; }
            set { transform.localScale = value; }
        }

        public Vector3 LossyScale {
            get { return transform.lossyScale; }
        }

        public bool Active {
            get { return gameObject.activeSelf; }
            set { gameObject.SetActive(value); }
        }

        public bool Inactive {
            get { return !gameObject.activeSelf; }
        }

        public bool Enabled {
            get { return enabled; }
            set { enabled = value; }
        }

        public bool Disabled {
            get { return !enabled; }
        }

        public void Activate() {
            gameObject.SetActive(true);
        }

        public void Deactivate() {
            gameObject.SetActive(false);
        }

        public void SetActive(bool active) {
            gameObject.SetActive(active);
        }

        public void Enable() {
            enabled = true;
        }

        public void Disable() {
            enabled = false;
        }

        public void SetEnabled(bool enable) {
            enabled = enable;
        }

        public void SetName(string name) {
            this.name = name;
        }

        public void SetParent(Transform parent) {
            transform.parent = parent;
        }

        public void SetLayer(int layer) {
            gameObject.layer = layer;
        }

        public void SetPosition(Vector3 position) {
            transform.position = position;
        }

        public void SetLocalPosition(Vector3 position) {
            transform.localPosition = position;
        }

        public void SetRotation(Quaternion rotation) {
            transform.rotation = rotation;
        }

        public void SetLocalScale(Vector3 scale) {
            transform.localScale = scale;
        }

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


