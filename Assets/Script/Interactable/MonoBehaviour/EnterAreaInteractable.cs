using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterAreaInteractable : Interactable
{
    public override void Interact(GameObject triggerObject)
    {
        for (int i = 0; i < conditionReactionCollectionArray.Count; i++)
        {
            conditionReactionCollectionArray[i].DoReaction(triggerObject, gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Interact(other.gameObject);
        }
    }
}
