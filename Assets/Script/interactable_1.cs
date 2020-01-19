using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable_1 : MonoBehaviour
{
    private bool E_Flag = true;

    public float CD = 0.5f;
    public float Next = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            if (Input.GetKey(KeyCode.E) && (Time.time > Next))
            {
                if (E_Flag)
                {
                    transform.Translate(new Vector3(0, 0, 1));
                    E_Flag = false;
                }
                else if (!E_Flag)
                {
                    transform.Translate(new Vector3(0, 0, -1));
                    E_Flag = true;
                }
                Next = Time.time + CD;
            }
            
        }
    }
}
