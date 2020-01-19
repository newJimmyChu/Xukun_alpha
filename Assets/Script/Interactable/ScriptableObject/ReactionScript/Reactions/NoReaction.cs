using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class NoReaction : Reaction
{
    public override bool DoReaction(GameObject triggerObject, GameObject interactObject)
    {
        Debug.Log("NO Reaction");
        return true;
    }
}
