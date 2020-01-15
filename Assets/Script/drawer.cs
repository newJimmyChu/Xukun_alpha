using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ddoor: MonoBehaviour
{
    private bool OpenCLoseFlag = false;
    private void OnMouseDown()
    {
        switch(OpenCLoseFlag)
        {
            case true:
                transform.Rotate(new Vector3(0, 270, 0));
                OpenCLoseFlag = false;
                break;
            case false:
                transform.Rotate(new Vector3(0, 90, 0));
                OpenCLoseFlag = true;
                break;
        }
    }
    private void OnMouseEnter()
    {
        print("Mouse_Enter");
    }
    private void OnMouseExit()
    {
        print("Mouse_Exit");
    }
}
