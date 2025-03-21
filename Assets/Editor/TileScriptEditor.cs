using UnityEngine;
using Unity;
using UnityEditor;

[CustomEditor(typeof(TileScript))]
public class TileScriptEditor : Editor
{
    SerializedProperty containsBombProp;
    SerializedProperty counterProp;

    private void OnEnable()
    {
        containsBombProp = serializedObject.FindProperty("containsBomb");
        counterProp = serializedObject.FindProperty("counter");
    }
    
    public override void OnInspectorGUI()
    {
        TileScript targetScript = (TileScript)target;
        
        // Draw all default serialized fields except the one you want to disable
        serializedObject.Update();

        // Draw 'number' normally
        EditorGUILayout.PropertyField(containsBombProp);
        if (containsBombProp.boolValue)
        {
            GUI.enabled = false;
            EditorGUILayout.PropertyField(counterProp);
            GUI.enabled = true;
        }
        else EditorGUILayout.PropertyField(counterProp);
        
        serializedObject.ApplyModifiedProperties();
    }
}
