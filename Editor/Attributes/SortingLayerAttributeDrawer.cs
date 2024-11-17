using UnityEditor;
using UnityEngine;

namespace BBUnity.Editor {
    [CustomPropertyDrawer(typeof(EditorAttributes.SortingLayerAttribute))]
    class SortingLayerAttributeDrawer : PropertyDrawer {

        private System.Reflection.MethodInfo _layerMethod = null;

        public SortingLayerAttributeDrawer() {
            _layerMethod = typeof(EditorGUI).GetMethod("SortingLayerField", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            _layerMethod.Invoke(null, new object[] { position, label, property, GUI.skin.textField, GUI.skin.label });
        }
    }
}