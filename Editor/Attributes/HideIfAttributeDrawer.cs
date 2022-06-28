using UnityEngine;
using UnityEditor;

namespace BBUnity.Editor {
    [CustomPropertyDrawer(typeof(HideIfAttribute))]
    public class HideIfAttributeDrawer : PropertyDrawer {

        private HideIfAttribute Attribute {
            get { return (HideIfAttribute)attribute; }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            bool enabled = GetConditionalHideAttributeResult(Attribute, property);
    
            bool wasEnabled = GUI.enabled;
            GUI.enabled = enabled;
            if (!enabled) {
                EditorGUI.PropertyField(position, property, label, true);
            }
    
            GUI.enabled = wasEnabled;
        }
 
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            bool enabled = GetConditionalHideAttributeResult(Attribute, property);
    
            if (!enabled) {
                return EditorGUI.GetPropertyHeight(property, label);
            }
            else {
                return -EditorGUIUtility.standardVerticalSpacing;
            }
        }
    
        protected bool GetConditionalHideAttributeResult(HideIfAttribute attr, SerializedProperty property) {
            //Finding the properties which we want to compare using
            string propertyPath = property.propertyPath;
            string conditionPath = propertyPath.Replace(property.name, attr.Field);
            SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);
    
            if (sourcePropertyValue != null) {
                return attr.IsMatching(sourcePropertyValue);
            }
            else {
                Debug.LogError("Attempting to use a HideIfAttribute but no matching field was found in object: " + attr.Field);
            }

            return false;
        }
    }
}