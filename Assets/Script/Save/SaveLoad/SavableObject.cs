using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SavableObject : MonoBehaviour
{
    public SavableObjectData data;
}

[System.Serializable]
public class SavableObjectData
{
    public Vector3 position;
    public int id;
    public string spritePath;
    public bool isEnable;
}
