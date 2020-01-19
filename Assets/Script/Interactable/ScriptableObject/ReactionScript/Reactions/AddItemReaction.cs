using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemReaction : Reaction
{
    public override bool DoReaction(GameObject triggerObject, GameObject interactObject)
    {
        bool succ = false;
        Player player = triggerObject.GetComponent<Player>();
        ClickInteractable interactObjectComponent = interactObject.GetComponent<ClickInteractable>();
        if (player)
        {
            if (interactObjectComponent.inventoryItem) 
            {
                player.playerInventory.addItemToInventory(interactObjectComponent.inventoryItem);
                succ = true;
            }
        }
        return succ;
    }

}
