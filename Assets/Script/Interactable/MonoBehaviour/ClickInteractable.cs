using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteractable : Interactable
{
    public override void Interact(GameObject triggerObject)
    {
        for (int i = 0; i < conditionReactionCollectionArray.Count; i++)
        {
            conditionReactionCollectionArray[i].DoReaction(triggerObject, gameObject);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        GameObject player = GameObject.Find("Virtual_Player");
        Interact(player);
    }
}
