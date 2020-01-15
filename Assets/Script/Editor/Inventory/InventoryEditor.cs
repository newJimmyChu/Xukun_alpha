using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Inventory))]
public class InventoryEditor : Editor
{
    public Inventory playerInventory;
    private SerializedProperty inventoryItemsProperty;
    private SerializedProperty inventoryItemImagesProperty;
    public bool[] itemFold = new bool[0];

    private const string inventoryPropInventoryItemsName = "inventoryItems";
    private const string inventoryPropInventoryItemImagesName = "itemImages";

    private void OnEnable() 
    {
        playerInventory = new Inventory();
        inventoryItemsProperty = serializedObject.FindProperty(inventoryPropInventoryItemsName);
        inventoryItemImagesProperty = serializedObject.FindProperty(inventoryPropInventoryItemImagesName);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        for (int i = 0; i < playerInventory.itemCount; i++) 
        {
            ItemSlotGUI(i);
        }

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Add Inventory Item")) 
        {
            AddInventoryItem();
        }

        if (GUILayout.Button("Remove Inventory Item")) 
        {
            RemoveInventoryItem();
        }

        EditorGUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }

    private void ItemSlotGUI(int index) 
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;
        itemFold[index] = EditorGUILayout.Foldout(itemFold[index], "Item " + index);

        if (!itemFold[index]) 
        {
            EditorGUILayout.PropertyField(inventoryItemsProperty.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField(inventoryItemImagesProperty.GetArrayElementAtIndex(index));
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
    }

    private void AddInventoryItem() 
    { 
        
    }

    private void RemoveInventoryItem() 
    {
    
    }
}
