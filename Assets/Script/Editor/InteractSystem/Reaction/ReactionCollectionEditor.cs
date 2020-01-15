using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ReactionCollection))]
public class ReactionCollectionEditor : Editor
{
    public SerializedProperty reactionCollectionProperty;
    private ReactionCollection editor;
    private bool fold = true;

    private void OnEnable() 
    {
        editor = (ReactionCollection)target;
        reactionCollectionProperty = serializedObject.FindProperty("reactionCollection");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        CustomEditorExtensions.CollectionEditorOnInspectorGUI(reactionCollectionProperty, "Reaction", this, ref fold);
        serializedObject.ApplyModifiedProperties();
    }

    public static ReactionCollection CreateReactionCollection(string description, string elementDescription) 
    {
        ReactionCollection newReactionCollection = CreateInstance<ReactionCollection>();
        newReactionCollection.reactionCollectionDescription = description;

        newReactionCollection.reactionCollection = new Reaction[1];
        newReactionCollection.reactionCollection[0] = ReactionEditor.CreateReaction(elementDescription, typeof(DefaultReaction));
        return newReactionCollection;
    }
}
