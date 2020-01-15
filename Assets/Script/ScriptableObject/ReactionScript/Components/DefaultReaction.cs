using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Default Reaction， 一个示例文件
// 用户可以创建自己的自定义 Reaction，添加自己的方法和变量，但是必须实现 DoReaction()
[CreateAssetMenu]
public class DefaultReaction : Reaction
{
    public override bool DoReaction(GameObject triggerObject, GameObject interactObject)
    {
        triggerObject.GetComponent<BallController>().points += 1;
        Debug.Log(triggerObject.GetComponent<BallController>().points);
        return true;
    }
}
