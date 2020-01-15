using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_V2: MonoBehaviour
{
    public float Mouse_speed = 1f;
    public float X_max = 80f;
    public float X_min = 300f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool Mouse_Left = Input.GetMouseButton(0);
        if (Mouse_Left)
        {
            float Mouse_Y = Input.GetAxis("Mouse Y");
            transform.Rotate(Mouse_Y * -1 * Mouse_speed, 0, 0);
            float local_X = transform.localEulerAngles.x;
            // print("local x = " + local_X);
            if (local_X > X_max && local_X < 180)
            {
                print("reset 80");
                Vector3 before = transform.localEulerAngles;
                transform.localEulerAngles = new Vector3(X_max, before.y, before.z);
            }

            if (local_X < 300 && local_X > 180)
            {
                print("reset 300");
                Vector3 before = transform.localEulerAngles;
                transform.localEulerAngles = new Vector3(X_min, before.y, before.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localPosition = new Vector3(0, -0.5f, 0);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localPosition = new Vector3(0, 0.5f, 0);
        }
    }
}
