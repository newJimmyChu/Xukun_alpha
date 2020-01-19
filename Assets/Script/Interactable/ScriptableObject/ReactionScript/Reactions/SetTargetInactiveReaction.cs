using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetInactiveReaction : Reaction
{
    public override bool DoReaction(GameObject triggerObject, GameObject interactObject)
    {
        interactObject.SetActive(false);
        if (interactObject.GetComponent<SavableObject>())
            interactObject.GetComponent<SavableObject>().enabled = false;
        return true;
    }
}
