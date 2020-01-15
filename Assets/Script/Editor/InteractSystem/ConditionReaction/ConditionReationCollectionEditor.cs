using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(ConditionReactionCollection))]
public class ConditionReationCollectionEditor : Editor
{
    private ConditionReactionCollection currentObject;
    public SerializedProperty conditionCollectionProperty;
    public SerializedProperty reactionCollectionProperty;

    private ConditionCollectionEditor conditionCollectionEditor;
    private ReactionCollectionEditor reactionCollectionEditor;

    private void OnEnable() 
    {
        currentObject = (ConditionReactionCollection)target;
        conditionCollectionProperty = serializedObject.FindProperty("conditionCollection");
        reactionCollectionProperty = serializedObject.FindProperty("reactionCollection");

        if (currentObject.conditionCollection == null)
        {
            ConditionReactionCollection newConditionReactionCollection = CreateConditionReactionCollection();
            currentObject.conditionCollection = newConditionReactionCollection.conditionCollection;
            currentObject.reactionCollection = newConditionReactionCollection.reactionCollection;
        }

        conditionCollectionEditor = CreateEditor(currentObject.conditionCollection) as ConditionCollectionEditor;
        reactionCollectionEditor = CreateEditor(currentObject.reactionCollection) as ReactionCollectionEditor;
    }


    private void OnDisable()
    {
        DestroyImmediate(conditionCollectionEditor);
        DestroyImmediate(reactionCollectionEditor);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUI.indentLevel++;
        GUILayout.BeginVertical(GUI.skin.box);

        conditionCollectionEditor.OnInspectorGUI();
        reactionCollectionEditor.OnInspectorGUI();

        GUILayout.Space(5.0f);

        GUILayout.EndVertical();
        EditorGUI.indentLevel--;
        GUILayout.Space(7.0f);
        serializedObject.ApplyModifiedProperties();
    }

    public static ConditionReactionCollection CreateConditionReactionCollection()
    {
        ConditionReactionCollection newConditionReactionCollection = CreateInstance<ConditionReactionCollection>();

        newConditionReactionCollection.conditionCollection =
            ConditionCollectionEditor.CreateConditionCollection("Default_Condtion_Collection", "Default_Condition");
        newConditionReactionCollection.reactionCollection =
            ReactionCollectionEditor.CreateReactionCollection("Default_Reaction_Collection", "Default_Reaction");

        return newConditionReactionCollection;
    }
}
