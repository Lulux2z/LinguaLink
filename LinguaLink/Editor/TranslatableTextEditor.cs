using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TranslatableText))]
public class TranslatableTextEditor : Editor
{
    private SerializedProperty useTMPProp;
    private SerializedProperty translationIDProp;

    private void OnEnable()
    {
        useTMPProp = serializedObject.FindProperty("useTMP");
        translationIDProp = serializedObject.FindProperty("translationID");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(useTMPProp, new GUIContent("Use TextMeshPro"));

        EditorGUILayout.Space(8);
        EditorGUILayout.PropertyField(translationIDProp);

        serializedObject.ApplyModifiedProperties();
    }
}
