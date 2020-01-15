using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AllCondition : ScriptableObject
{
    public Condition[] allCondition;
    private static AllCondition instance;
    public static AllCondition Instance 
    {
        get 
        {
            if (!instance)
                instance = FindObjectOfType<AllCondition>();
            // If the instance is still null, try to load it from the Resources folder.
            if (!instance)
                instance = Resources.Load<AllCondition>("AllCondition");
            return instance;
        }
        set
        { instance = value; }
    }


    // If the newCondition is not already in the list, add them
    public void AddConditionToAllCondition(Condition newCondition) 
    {
        //foreach (Condition condition in allCondition) 
        //{
        //    if (condition.conditionDescription == newCondition.conditionDescription)
        //        return;
        //}
        //allCondition.Add(newCondition);
    }

    // Remove the given condition if it is already in the list
    public void RemoveConditionFromAllCondition(Condition conditionToRemove) 
    {
        //allCondition.Remove(allCondition.Find
        //    (x => x.conditionDescription == conditionToRemove.conditionDescription));
    }
    
}
