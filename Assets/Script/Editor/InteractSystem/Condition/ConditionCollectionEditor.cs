using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConditionCollection))]
public class ConditionCollectionEditor : Editor
{
    public SerializedProperty conditionCollectionProperty;
    private ConditionCollection editor;
    private bool fold = true;

    private void OnEnable() 
    {
        editor = (ConditionCollection)target;
        conditionCollectionProperty = serializedObject.FindProperty("conditionCollection");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        CustomEditorExtensions.CollectionEditorOnInspectorGUI(conditionCollectionProperty, "Condition", this, ref fold);
        serializedObject.ApplyModifiedProperties();
    }

    public static ConditionCollection CreateConditionCollection(string description, string elementDescription) 
    {
        ConditionCollection newConditionCollection = CreateInstance<ConditionCollection>();

        // Give it a default description.
        newConditionCollection.conditionCollectionDescription = description;

        // Give it a single default Condition.
        newConditionCollection.conditionCollection = new Condition[1];
        newConditionCollection.conditionCollection[0] = ConditionEditor.CreateCondition(elementDescription, typeof(DefaultCondition));
        return newConditionCollection;
    }
}
