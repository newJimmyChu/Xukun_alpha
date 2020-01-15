using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Move: MonoBehaviour
{
    public float Movement_Speed = 4f;
    public float Turning_Speed = 180f;

    public float Jump_Power = 10f;
    public float Next_Jump = 0f;
    public float Jump_CD = 0.7f;

    private Rigidbody rb;
    private Collider C;

    public float Mouse_speed = 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        C = GetComponent<CapsuleCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        float WS = Input.GetAxis("Vertical");
        float AD = Input.GetAxis("Horizontal");
        float Mouse_X = Input.GetAxis("Mouse X");
        bool Space = Input.GetKey(KeyCode.Space);
        ApplyInput(WS, AD, Mouse_X, Space);
    }
    private void ApplyInput(float WS, float AD, float Mouse_X, bool Space)
    {
        Move(WS, AD);
        Turn(Mouse_X);

        if (Space && (Time.time > Next_Jump))
        {
            print("Jump");
            Next_Jump = Time.time + Jump_CD;
            Jump();
        }
    }
    private void Move(float input_WS, float input_AD)
    {
        transform.Translate(Vector3.forward * input_WS * Movement_Speed);
        transform.Translate(Vector3.right * input_AD * Movement_Speed);
        // rb.AddForce(transform.forward * input * Movement_Speed, ForceMode.Force);
    }
    private void Turn(float input_Mouse_X)
    {
        // transform.Rotate(0,input * Turning_Speed * Time.deltaTime,0);
        transform.Rotate(0, input_Mouse_X * Mouse_speed, 0);
    }
    private void Jump()
    {
        rb.AddForce(transform.up * Jump_Power, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            print("IsGrounded");
        }
    }


}
