using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class SerializedPropertyExtensions
{
    public static void AddElementToProperty<T>(this SerializedProperty arrayProperty, T itemToAdd) 
    {
        arrayProperty.serializedObject.Update();
        arrayProperty.InsertArrayElementAtIndex(arrayProperty.arraySize);
        arrayProperty.GetArrayElementAtIndex(arrayProperty.arraySize - 1).objectReferenceValue = itemToAdd as Object;
        arrayProperty.serializedObject.ApplyModifiedProperties();
    }

    public static void AddEmptyElementToProperty(this SerializedProperty arrayProperty) 
    {
        arrayProperty.serializedObject.Update();
        arrayProperty.InsertArrayElementAtIndex(arrayProperty.arraySize);
        arrayProperty.serializedObject.ApplyModifiedProperties();
    }

    public static void RemoveElementFromProperty<T>(this SerializedProperty arrayProperty, T itemToRemove) 
    {
        arrayProperty.serializedObject.Update();
        for (int i = 0; i < arrayProperty.arraySize; i++) 
        {
            if (arrayProperty.GetArrayElementAtIndex(i).objectReferenceValue == itemToRemove as Object) 
            {
                arrayProperty.DeleteArrayElementAtIndex(i);
            }
        }
        arrayProperty.serializedObject.ApplyModifiedProperties();
    }

    public static void RemoveElementFromPropertyByIndex(this SerializedProperty arrayProperty, int index) 
    {
        arrayProperty.serializedObject.Update();
        if (arrayProperty.arraySize > 0)
        {
            if (arrayProperty.GetArrayElementAtIndex(index).objectReferenceValue != null)
            {
                arrayProperty.DeleteArrayElementAtIndex(index);
            }
        }
        arrayProperty.DeleteArrayElementAtIndex(index);
        arrayProperty.serializedObject.ApplyModifiedProperties();
    }
}
