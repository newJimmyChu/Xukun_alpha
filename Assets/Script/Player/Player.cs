using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // Object variables 
    // Define new Player attribute here 
    private Rigidbody rb;
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!playerInventory) 
        {
            playerInventory = GameObject.Find("Inventory").gameObject.GetComponent<Inventory>();
        }
        SaveLoad.SetUpInitialAllSavableObject();
    }

    public void SaveAllData()
    {
        SaveLoad.SavePlayerDataToFile(this);
        SaveLoad.SaveAllSavableObject();
        Debug.Log("Save");
    }

    public void LoadAllData()
    {
        PlayerData playerData = SaveLoad.LoadPlayerDataFromFile();
        if (playerData != null)
        {
            gameObject.transform.position = playerData.playerPosition;
            for (int i = 0; i < playerData.playerItemPath.Length; i++)
            {
#if UNITY_EDITOR 
                InventoryItem item =
                    AssetDatabase.LoadAssetAtPath(playerData.playerItemPath[i], typeof(InventoryItem)) as InventoryItem;
                if (item != null)
                {
                    playerInventory.inventoryItems[i] = item;
                    playerInventory.itemImages[i].sprite = item.itemSprite;
                    playerInventory.itemImages[i].enabled = true;
                }
#endif
            }
        }

        foreach (SavableObjectData savedObj in SaveLoad.LoadAllSavableObject())
        {
            SavableObject[] list = SaveLoad.savableObjects;
            SavableObject obj = Array.Find(list, (SavableObject x) => (x.data.id == savedObj.id));
            if (obj != null)
            {
                obj.gameObject.transform.position = obj.data.position;
                obj.gameObject.SetActive(obj.data.isEnable);
            }
        }
    }

}

