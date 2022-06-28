using UnityEngine;
using UnityEditor;
using System;

namespace BBUnity {

    /// <summary>
    /// Enables the hiding of a property based on either true / false or 
    /// via a comparer
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public class HideIfAttribute : PropertyAttribute {

        /// <summary>
        /// The field name which should be checked for the match
        /// </summary>
        private string _field;

        /// <summary>
        /// The Lambda which can be called to check for a match
        /// </summary>
        private Func<SerializedProperty, bool> _comparer;

        public string Field {
            get { return _field; }
        }

        public Func<SerializedProperty, bool> Comparer {
            get { return _comparer; }
        }

        public bool IsMatching(SerializedProperty property) {
            if(_comparer != null) {
                return _comparer(property);
            } else {
                return property.boolValue;
            }
        }

        public HideIfAttribute(string field) {
            _field = field;
            _comparer = null;
        }

        public HideIfAttribute(string field, Func<SerializedProperty, bool> comparer) {
            _field = field;
            _comparer = comparer;
        }
    }
}
