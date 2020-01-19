using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReactionCollection 是一个可以被实例化的脚本， 用来储存多个属于 Reaction 的子类实例化对象
public class ReactionCollection : ScriptableObject
{
    public Reaction[] reactionCollection;
    public string reactionCollectionDescription;

    // 对每一个存在于 reactionCollection 中的对象运行 DoReaction 函数
    public bool DoReactionFromCollection(GameObject triggerObject, GameObject interactObject) 
    {
        bool allSuccess = true;
        foreach (Reaction reaction in reactionCollection) 
        {
            if (!reaction.DoReaction(triggerObject, interactObject)) 
            {
                allSuccess = false;
            }
        }
        return allSuccess;
    }
}
