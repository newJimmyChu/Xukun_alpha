using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


public class ItemClick : MonoBehaviour
    , IPointerClickHandler
{
    public GameObject player;
    public int index;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        InventoryItem reactiveItem = 
            player.GetComponent<Player>().playerInventory.removeItemFromInventoryByIndex(index);
        if (reactiveItem) 
        {
            reactiveItem.itemObject.SetActive(true);
            reactiveItem.itemObject.GetComponent<SavableObject>().enabled = true;
            reactiveItem.itemObject.transform.position = player.transform.position + new Vector3(0, 0, 1.0f);
            Debug.Log("Succ");
        }
        
        //reactiveItem.itemObject.gameObject.transform.rotation = new Quaternion(90.0f, 0, 0, 0);
    }

}
