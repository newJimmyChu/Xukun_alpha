using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryItem : ScriptableObject
{
    [SerializeField] 
    public Sprite itemSprite;
    [SerializeField] 
    public GameObject itemObject;
}
