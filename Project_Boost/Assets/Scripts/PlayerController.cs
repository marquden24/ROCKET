using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float thrustforce = 2000f;
    [SerializeField] private float rotationforce = 2000f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
        ProcessThrust();
    }

    void ProcessThrust()
    {
         if(Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce( Vector3.up * thrustforce *  Time.deltaTime);
            
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce( Vector3.down * thrustforce *  Time.deltaTime);
            
        }
        
    }

    void ProcessRotation()
    { 
       
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationforce);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationforce);
        }

    }

    private void ApplyRotation(float rotationValue)
    {
        rb.freezeRotation = true; 
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
