using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 一个包含 Conditions 和 Reactions 集合的可实例化脚本
// 机制：先遍历 ConditionCollection 中所有的对象，如果全部返还 True，则运行 ReactionCollection 中所有的 Reactions
public class ConditionReactionCollection : ScriptableObject
{
    // Condition 集合
    public ConditionCollection conditionCollection;
    // Reaction 集合
    public ReactionCollection reactionCollection;

    // DoReaction遍历所有的conditions，如果所有conditions全部满足，运行相应的Reactions
    public void DoReaction(GameObject triggerObject, GameObject interactObject) 
    {
        if (conditionCollection.CheckAllConditions(triggerObject, interactObject)) 
        {
            reactionCollection.DoReactionFromCollection(triggerObject, interactObject);
        }
    }
}
