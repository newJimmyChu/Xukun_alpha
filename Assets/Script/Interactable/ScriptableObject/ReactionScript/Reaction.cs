using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reaction 和 Condition 一样，都是一个抽象类
// 使用时需要implement DoReaction 方法
public abstract class Reaction : ScriptableObject
{
    public string reactionDescription;

    public abstract bool DoReaction(GameObject triggerObject, GameObject interactObject);
}
