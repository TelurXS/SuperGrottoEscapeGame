using UnityEngine;
using UnityEditor;
using Stats;

namespace Utils
{
    //[CustomPropertyDrawer(typeof(Stat))]
    public class StatPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var valueRect = new Rect(position.x, position.y, 30, position.height);
            var minRect = new Rect(position.x + 35, position.y, 50, position.height);
            var maxRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

            EditorGUI.PropertyField(valueRect, property.FindPropertyRelative(nameof(Stat.Value)), GUIContent.none);
            EditorGUI.PropertyField(minRect, property.FindPropertyRelative(nameof(Stat.Min)), GUIContent.none);
            EditorGUI.PropertyField(maxRect, property.FindPropertyRelative(nameof(Stat.Max)), GUIContent.none);

            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}

