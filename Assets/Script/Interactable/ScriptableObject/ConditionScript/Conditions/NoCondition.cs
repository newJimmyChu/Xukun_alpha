using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class NoCondititon : Condition
{
    public override bool CheckCondition(GameObject triggerObject, GameObject interactObject)
    {
        
        return true;
    }
}
