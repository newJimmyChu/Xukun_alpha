using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Conditional class is a scriptable object representing the single condition to trigger 
// some specific reactions (or events)

// Condition 是一个抽象类，用来规范ConditionEditor
// 不可以直接创建 Condition 的对象或脚本， 使用 Condition 的时候需要创建一个子类 e.g. ItemCondition : Condition
// 子类需要实现抽象类中的 CheckCondition 函数
public abstract class Condition : ScriptableObject
{
    public string conditionDescription;

    // Run the script in the sub Condtion class, attach the script and run the CheckCondition
    public abstract bool CheckCondition(GameObject triggerObject, GameObject interactObject);
}
