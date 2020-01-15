using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

// CustomEditorExtensions 负责储存所有关于Editor相关的泛型方法
public static class CustomEditorExtensions
{
    // CollectionEditorOnInspectorGUI 是一个泛型方法，负责对所有的 CollectionEditor 相关的编辑器进行渲染
    // 使用的时候需要在相应的 CollectionEditor 的 OnInspectorGUI() 中 call 这个function
    public static void CollectionEditorOnInspectorGUI<T>(SerializedProperty collectionProperty, 
                                                            string name, T editor, ref bool fold) 
        where T : Editor
    {
        //EditorGUI.indentLevel++;
        GUILayout.BeginVertical(GUI.skin.box);

        fold = EditorGUILayout.Foldout(fold, name + " Collection");
        if (fold) 
        {
            EditorGUI.indentLevel++;

            for (int i = 0; i < collectionProperty.arraySize; i++) 
            {
                GUILayout.BeginHorizontal();
                SerializedProperty elementProperty = collectionProperty.GetArrayElementAtIndex(i);
                EditorGUILayout.PropertyField(elementProperty);
                if (GUILayout.Button("-", GUILayout.Width(18.0f))) 
                {
                    collectionProperty.RemoveElementFromPropertyByIndex(i);
                }
                GUILayout.EndHorizontal();
            }

            EditorGUI.indentLevel--;

            GUILayout.Space(5.0f);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            string buttonStr = "Add New " + name;
            if (GUILayout.Button(buttonStr, GUILayout.Width(150.0f)))
            {
                collectionProperty.AddEmptyElementToProperty();
            }

            buttonStr = "Remove " + name;
            if (GUILayout.Button(buttonStr, GUILayout.Width(150.0f)))
            {
                int index = collectionProperty.arraySize;
                collectionProperty.RemoveElementFromPropertyByIndex(index - 1);
            }

            GUILayout.EndHorizontal();
            GUILayout.Space(5.0f);

            Rect fullWidthRect = GUILayoutUtility.GetRect(GUIContent.none, GUIStyle.none, GUILayout.Height(60.0f));
            DragAndDropAreaGUI(fullWidthRect, CheckEditorTargetType(editor).ToString());
            DraggingAndDropping(fullWidthRect, editor);
        }


        GUILayout.EndVertical();
        //EditorGUI.indentLevel--;

    }

    // DragAndDropAreaGUI 负责渲染拖拽区域
    private static void DragAndDropAreaGUI(Rect containingRect, string name)
    {
        // Create a GUI style of a box but with middle aligned text and button text color.
        GUIStyle centredStyle = GUI.skin.box;
        centredStyle.alignment = TextAnchor.MiddleCenter;
        centredStyle.normal.textColor = GUI.skin.button.normal.textColor;

        // Draw a box over the area with the created style.
        GUI.Box(containingRect, "Drop new " + name + " script here", centredStyle);
    }

    // IsDragValid 用来判断被拖拽的 Script 的类型是否和 Editor 的 target 的类型相同
    private static bool IsDragValid(Type allowedScriptType)
    {
        // Go through all the objects being dragged...
        for (int i = 0; i < DragAndDrop.objectReferences.Length; i++)
        {
            // ... and if any of them are not script assets, return that the drag is invalid.
            if (DragAndDrop.objectReferences[i].GetType() != typeof(MonoScript))
                return false;

            // Otherwise find the class contained in the script asset.
            MonoScript script = DragAndDrop.objectReferences[i] as MonoScript;
            Type scriptType = script.GetClass();

            if (!scriptType.IsSubclassOf(allowedScriptType))
            {
                return false;
            }
            if (scriptType.IsAbstract)
                return false;
        }
        return true;
    }

    // DraggingAndDropping 用来对拖拽进来的 ScriptableObject（Script） 进行实例化
    // 并将其添加到相应的 Collection 中
    private static void DraggingAndDropping<T>(Rect dropArea, T editor)
        where T : Editor
    {
        // Cache the current event.
        Event currentEvent = Event.current;
        Type editorType = editor.GetType();

        // Default type is Condition
        Type allowedScriptType = CheckEditorTargetType(editor);

        // If the drop area doesn't contain the mouse then return.
        if (!dropArea.Contains(currentEvent.mousePosition))
            return;

        switch (currentEvent.type)
        {
            case EventType.DragUpdated:

                DragAndDrop.visualMode = IsDragValid(allowedScriptType) ? DragAndDropVisualMode.Link : DragAndDropVisualMode.Rejected;
                currentEvent.Use();
                break;

            // If the mouse was dragging something and has released...
            case EventType.DragPerform:

                DragAndDrop.AcceptDrag();

                // Go through all the objects that were being dragged...
                for (int i = 0; i < DragAndDrop.objectReferences.Length; i++)
                {
                    MonoScript script = DragAndDrop.objectReferences[i] as MonoScript;

                    // ... then find the type of that Reaction...
                    Type scriptType = script.GetClass();

                    // ... and create a Reaction of that type and add it to the array.
                    if (editorType.Equals(typeof(ReactionCollectionEditor)))
                    {
                        Reaction newReaction = ReactionEditor.CreateReaction("Default_Reaction", scriptType);
                        ReactionCollectionEditor castedEditor = (ReactionCollectionEditor)(Editor)editor;
                        castedEditor.reactionCollectionProperty.AddElementToProperty(newReaction);
                    }
                    else if (editorType.Equals(typeof(ConditionCollectionEditor)))
                    {
                        Condition newCondition = ConditionEditor.CreateCondition("Default_Condition", scriptType);
                        ConditionCollectionEditor castedEditor = (ConditionCollectionEditor)(Editor)editor;
                        castedEditor.conditionCollectionProperty.AddElementToProperty(newCondition);
                    }
                    else if (editorType.Equals(typeof(AllConditionEditor))) 
                    {
                        Condition newCondition = ConditionEditor.CreateCondition("Default_Condition", scriptType);
                        AllConditionEditor castedEditor = (AllConditionEditor)(Editor)editor;
                        castedEditor.allConditionProperty.AddElementToProperty(newCondition);
                    }
                }

                // Make sure the event isn't used by anything else.
                currentEvent.Use();

                break;
        }
    }

    // 不要改动
    private static Type CheckEditorTargetType<T>(T editor) 
    {
        Type editorType = editor.GetType();
        if (editorType.Equals(typeof(ReactionCollectionEditor)))
        {
            return typeof(Reaction);
        }
        else if (editorType.Equals(typeof(ConditionCollectionEditor)))
        {
            return typeof(Condition);
        }
        else if (editorType.Equals(typeof(AllConditionEditor)))
        {
            return typeof(Condition);
        }
        return typeof(Condition);
    }

}
