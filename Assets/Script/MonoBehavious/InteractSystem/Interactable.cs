using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用来 attach 到 gameObject 上的脚本，不可以被实例化，是一个抽象类
// 可以在物体中选择该脚本，添加相应的 Conditions 和 Reactions
// 使用时需要在子类中 实现相应的 Interact()
public abstract class Interactable : MonoBehaviour
{
    // 如果需要判断玩家与物体之间的位置，使用interactPosition来判断
    public Transform interactPosition;
    public List<ConditionReactionCollection> conditionReactionCollectionArray;

    // Interactable的子类需要实现相应的 Interact 方法。
    public abstract void Interact(GameObject triggerObject);

}
