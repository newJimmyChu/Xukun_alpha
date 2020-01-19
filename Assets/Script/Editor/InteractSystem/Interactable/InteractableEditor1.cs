using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public SerializedProperty interactAreaColliderProperty;
    public SerializedProperty conditionReactionCollectionArrayProperty;
    public SerializedProperty inventorySpriteProperty;
    private List<ConditionReationCollectionEditor> conditionReactionCollectionEditor;
    private Interactable interactable;
    

    private void OnEnable() 
    {
        interactable = (Interactable)target;
        // If there is no conditionReactionCollectionArray exists

        if (interactable.conditionReactionCollectionArray == null)
        {
            interactable.conditionReactionCollectionArray = new List<ConditionReactionCollection>();

            // Create a new Instance has typeof(ConditionReationCollection) and add it to the list
            interactable.conditionReactionCollectionArray.Add(ConditionReationCollectionEditor.CreateConditionReactionCollection());
        }

        conditionReactionCollectionEditor = new List<ConditionReationCollectionEditor>();

        interactAreaColliderProperty = serializedObject.FindProperty("interactAreaCollider");
        inventorySpriteProperty = serializedObject.FindProperty("itemSprite");
        conditionReactionCollectionArrayProperty = serializedObject.FindProperty("conditionReactionCollectionArray");

        for (int i = 0; i < interactable.conditionReactionCollectionArray.Count; i++) 
        {
            conditionReactionCollectionEditor.Add( 
                CreateEditor(interactable.conditionReactionCollectionArray[i]) as ConditionReationCollectionEditor);
            Debug.Log(interactable.conditionReactionCollectionArray[i]);
        }
        Debug.Log("OnEnable");

    }

    private void OnDisable() 
    {
        for (int i = 0; i < conditionReactionCollectionEditor.Count; i++) 
        {
            DestroyImmediate(conditionReactionCollectionEditor[i]);
        }
        conditionReactionCollectionEditor = null;
        Debug.Log("OnDisable");
        
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //EditorGUI.indentLevel++;

        GUILayout.BeginVertical(GUI.skin.box);

        EditorGUILayout.PropertyField(inventorySpriteProperty);
        EditorGUILayout.PropertyField(interactAreaColliderProperty);
        GUILayout.Space(3.0f);

        for (int i = 0; i < conditionReactionCollectionEditor.Count; i++) 
        {
            conditionReactionCollectionEditor[i].OnInspectorGUI();
        }

        GUILayout.BeginHorizontal();

        // If user press the button, add a new ConditionReationCollection and an Editor binding with it
        if (GUILayout.Button("Add new Conditions->Reactions", GUILayout.Width(240.0f)))
        {
            conditionReactionCollectionArrayProperty.AddElementToProperty
                (ConditionReationCollectionEditor.CreateConditionReactionCollection());

            conditionReactionCollectionEditor.Add(
                CreateEditor(interactable.conditionReactionCollectionArray[interactable.conditionReactionCollectionArray.Count - 1])
                as ConditionReationCollectionEditor);
        }

        // If user press the button, remove the last item form the list, and destory the binding editor
        if (GUILayout.Button("Remove Conditions->Reactions", GUILayout.Width(240.0f)))
        {
            int index = interactable.conditionReactionCollectionArray.Count - 1;
            conditionReactionCollectionArrayProperty.RemoveElementFromPropertyByIndex(index);
            DestroyImmediate(conditionReactionCollectionEditor[index]);
            conditionReactionCollectionEditor.RemoveAt(index);
        }
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        //EditorGUI.indentLevel--;
        serializedObject.ApplyModifiedProperties();
    }

}
