using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public int points;
    public float speed;
    public float collisionFactor;
    public string[] playerItemPath = { "Assets/Inventory/item1.asset" , "Assets//Inventory/item2.asset",
        "Assets/Inventory/item3.asset", "Assets/Inventory/item4.asset", "Assets/Inventory/item5.asset" };
    public bool[] playerItemActive = { false, false, false, false, false };
    //public Image[] playereInventoryImages;
    public Vector3 playerPosition;

    // 存储 Player 的数据
    public PlayerData(Player ball) 
    {
        playerPosition = ball.transform.position;
    }
}
