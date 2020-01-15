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
}
