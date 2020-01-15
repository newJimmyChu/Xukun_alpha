using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Condition))]
public class ConditionEditor : Editor
{
    public SerializedProperty conditionDescriptionProperty;
    public SerializedProperty satisfiedProperty;

    void OnEnable() 
    {
        conditionDescriptionProperty = serializedObject.FindProperty("conditionDescription");
        satisfiedProperty = serializedObject.FindProperty("satisfied");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUILayout.BeginHorizontal(GUI.skin.box);

        EditorGUILayout.PropertyField(conditionDescriptionProperty);

        GUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }

    public static Condition CreateCondition(string description, Type type) 
    {
        Condition newCondition = (Condition)CreateInstance(type);
        newCondition.conditionDescription = description;
        return newCondition;
    }
}
