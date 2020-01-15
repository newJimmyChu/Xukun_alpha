using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Default Condition， 一个示例文件
// 用户可以创建自己的自定义 Condition，添加自己的方法和变量，但是必须实现 CheckCondition()
[CreateAssetMenu]
public class DefaultCondition : Condition
{
    public override bool CheckCondition(GameObject triggerObject, GameObject interactObject)
    {
        Debug.Log("Inside CheckCondition");
        return true;
    }

}
