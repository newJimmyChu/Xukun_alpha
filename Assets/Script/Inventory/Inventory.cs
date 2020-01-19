using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    public const int itemCount = 5;     // Declaring constant and variables
    [SerializeField]
    public InventoryItem[] inventoryItems = new InventoryItem[itemCount];
    [SerializeField]
    public Image[] itemImages = new Image[itemCount];

    public void addItemToInventory(InventoryItem itemToAdd) 
    {
        for (int i = 0; i < inventoryItems.Length; i++)  
        {
            if (!inventoryItems[i]) 
            {
                inventoryItems[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.itemSprite;
                itemImages[i].enabled = true;
                return;

            }
        }
    }

    public void removeItemFromInventory(InventoryItem itemToRemove) 
    {
        for (int i = 0; i < inventoryItems.Length; i++) 
        {
            if (inventoryItems[i] == itemToRemove) 
            {
                inventoryItems[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    public InventoryItem removeItemFromInventoryByIndex(int index)
    {
        InventoryItem removedItem = ScriptableObject.CreateInstance<InventoryItem>();
        if (inventoryItems[index]) 
        {
            removedItem.itemObject = inventoryItems[index].itemObject;
            removedItem.itemSprite = inventoryItems[index].itemSprite;
            inventoryItems[index] = null;
            itemImages[index].enabled = false;
            itemImages[index].sprite = null;
            Debug.Log(removedItem.itemObject);
            return removedItem;
        }
        return null;
    }

    void Start()
    {
        //itemImages = new Image[itemCount];
        //inventoryItems = new InventoryItem[itemCount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
