using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ConditionCollection 是一个可以被实例化的脚本， 用来储存多个属于 Condition 的子类实例化对象
public class ConditionCollection : ScriptableObject
{
    public Condition[] conditionCollection;
    public string conditionCollectionDescription;

    // 遍历 conditionCollection， 运行 CheckCondition 函数， 返还一个 bool 变量
    public bool CheckAllConditions(GameObject triggerObject, GameObject interactObject) 
    {
        bool allTure = true;
        foreach (Condition condition in conditionCollection) 
        {
            if (!condition.CheckCondition(triggerObject, interactObject)) 
            {
                allTure = false;
            }
        }
        return allTure;
    }
}
