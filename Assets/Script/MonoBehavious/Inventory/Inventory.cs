using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    public int itemCount = 4;     // Declaring constant and variables
    public InventoryItem[] inventoryItems;
    public Image[] itemImages;

    public void addItemToInventory(InventoryItem itemToAdd) 
    {
        for (int i = 0; i < inventoryItems.Length; i++) 
        {
            if (!inventoryItems[i]) 
            {
                inventoryItems[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
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
                itemImages[i] = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    void Start()
    {
        itemImages = new Image[itemCount];
        inventoryItems = new InventoryItem[itemCount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
