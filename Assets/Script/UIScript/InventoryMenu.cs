using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public GameObject InventoryMenuUI;
    private bool isInventoryMenuOpen =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void inventoryOnClick() 
    {
        if (isInventoryMenuOpen)
        {
            InventoryMenuUI.SetActive(false);
            isInventoryMenuOpen = false;
            Debug.Log(isInventoryMenuOpen.ToString());
        }
        else
        {
            
            InventoryMenuUI.SetActive(true);
            isInventoryMenuOpen = true;
            Debug.Log(isInventoryMenuOpen.ToString());
        }
    
    
    }
}
