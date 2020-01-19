using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotateSpeed = 100.0f;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, 45.0f)* Time.deltaTime);
    }
}
