using UnityEngine;
using UnityEditor;
using System;

public class ReactionEditor : Editor
{
    public SerializedProperty reactionDescriptionProperty;

    private void OnEnable() 
    {
        reactionDescriptionProperty = serializedObject.FindProperty("reactionDescription");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUILayout.BeginHorizontal(GUI.skin.box);

        EditorGUILayout.PropertyField(reactionDescriptionProperty);

        GUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }

    public static Reaction CreateReaction(string description, Type type) 
    {
        Reaction newReaction = (Reaction)CreateInstance(type);
        newReaction.reactionDescription = description;
        return newReaction;
    }
}