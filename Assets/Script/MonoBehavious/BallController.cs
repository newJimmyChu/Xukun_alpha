using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Object variables
    private Rigidbody rb;
    private bool ground;
    public int points;
    public float speed;
    public float collisionFactor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ground = true;
        points = 0;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal * Time.deltaTime, 0.0f, moveVertical * Time.deltaTime);
        rb.AddForce(move * speed);
        if (Input.GetButtonDown("Jump")) 
        {
            if (ground)
            {
                rb.AddForce(Vector3.up * speed);
                ground = false;
            }
        }

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            ground = true;
        }

    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Destructible") 
        {
            Destroy(other.gameObject);
            points += 1;
        }
        else if (other.gameObject.tag == "Interactable")
        {
            Debug.Log("Inside OnCollisionEnter");
            EnterAreaInteractable interactableObject = other.gameObject.GetComponent<EnterAreaInteractable>();
            interactableObject.Interact(gameObject);
        }
    }
}

