using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideAreaCondition : Condition
{
    public override bool CheckCondition(GameObject triggerObject, GameObject interactObject)
    {
        ClickInteractable cache = interactObject.GetComponent<ClickInteractable>();
        if (cache) 
        {   
            return cache.interactAreaCollider.bounds.Intersects(triggerObject.GetComponent<Collider>().bounds);
        }

        return false;
        //Debug.Log("aaaaaaaaaaaaa");
        //
        //if (cache) 
        //{
        //    Debug.Log(cache.interactAreaCollider.transform);
        //    return cache.interactAreaCollider.bounds.Contains(triggerObject.transform.position);
        //}
        //return false;
    }
}
