using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;

public static class SaveLoad
{
    private const string filePath = "/playerSave.json";
    private const string allObjectFilePath = "/objectSave.json";
    public static SavableObject[] savableObjects;

    public static void SetUpInitialAllSavableObject() 
    {
        savableObjects = Resources.FindObjectsOfTypeAll(typeof(SavableObject)) as SavableObject[];
    }

    public static void SavePlayerDataToFile(Player ball) 
    {

        // 复制当前 player 对象的数据到 PlayerData 中
        // 并对其添加 JSON 对象
        PlayerData data = new PlayerData(ball);
        string json = JsonUtility.ToJson(data);

        for (int i = 0; i < ball.playerInventory.inventoryItems.Length; i++)
        {
#if UNITY_EDITOR
            if (ball.playerInventory.inventoryItems[i] != null)
            {
                if (!AssetDatabase.Contains(ball.playerInventory.inventoryItems[i]))
                    AssetDatabase.CreateAsset(ball.playerInventory.inventoryItems[i], data.playerItemPath[i]);
                else
                {
                    
                    //AssetDatabase.DeleteAsset(data.playerItemPath[i]);
                    //AssetDatabase.CreateAsset(ball.playerInventory.inventoryItems[i], data.playerItemPath[i]);
                }

                //AssetDatabase.SaveAssets();
            }
            else 
            {
                if (AssetDatabase.LoadAssetAtPath(data.playerItemPath[i], typeof(InventoryItem)))
                    AssetDatabase.DeleteAsset(data.playerItemPath[i]);
            }
#endif
        }

        // 将生成的 JSON 字符串写入到 file 里面
        string savePath = Application.dataPath + filePath;
        File.WriteAllText(savePath, json);

    }

    public static PlayerData LoadPlayerDataFromFile() 
    {
        string savePath = Application.dataPath + filePath;
        string json = File.ReadAllText(savePath);
        return JsonUtility.FromJson<PlayerData>(json) as PlayerData;
    }

    public static void SaveAllSavableObject() 
    {
        SavableObject[] savableObjects =
            Resources.FindObjectsOfTypeAll(typeof(SavableObject)) as SavableObject[];
        SavableObjectData[] dataArray = new SavableObjectData[savableObjects.Length];
        for (int i = 0; i < savableObjects.Length; i++) 
        {
            dataArray[i] = savableObjects[i].data;
            dataArray[i].position = savableObjects[i].gameObject.transform.position;
            dataArray[i].isEnable = savableObjects[i].gameObject.activeSelf;
        }

        string json = JsonHelper.ToJson(dataArray);
        string savePath = Application.dataPath + allObjectFilePath;
        File.WriteAllText(savePath, json);
    }

    public static SavableObjectData[] LoadAllSavableObject() 
    {
        string savePath = Application.dataPath + allObjectFilePath;
        string json = File.ReadAllText(savePath);

        SavableObjectData[] savedObjects = JsonHelper.FromJson<SavableObjectData>(json) as SavableObjectData[];
        return savedObjects;
    }

}
