using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AllCondition))]
public class AllConditionEditor : Editor
{
    public SerializedProperty allConditionProperty;
    private AllCondition editor;
    private bool fold = true;

    private void OnEnable() 
    {
        editor = (AllCondition)target;
        allConditionProperty = serializedObject.FindProperty("allCondition");
    }

    private void OnDisable() 
    {

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        CustomEditorExtensions.CollectionEditorOnInspectorGUI(allConditionProperty, "Condition", this, ref fold);
        serializedObject.ApplyModifiedProperties();
    }

    [MenuItem("Tools/Create AllCondition")]
    public static void CreateAllConditionAsset() 
    {
        if (AllCondition.Instance)
            return;
        AllCondition newInstance = CreateInstance<AllCondition>();
        AssetDatabase.CreateAsset(newInstance, "Assets/Resources/AllCondition.asset");
        AllCondition.Instance = newInstance;
        AllCondition.Instance.allCondition = new Condition[0];
    }
}
