﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer : MonoBehaviour
{
    private bool OpenCLoseFlag = false;
    private void OnMouseDown()
    {
        switch(OpenCLoseFlag)
        {
            case true:
                transform.Translate(new Vector3(0, 0, -0.6f));
                OpenCLoseFlag = false;
                break;
            case false:
                transform.Translate(new Vector3(0, 0, 0.6f));
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
