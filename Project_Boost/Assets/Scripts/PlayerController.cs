using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float thrustforce = 2000f;
    [SerializeField] private float rotationforce = 2000f;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame


    public void Thrust()
    {
            rb.AddRelativeForce( Vector3.up * thrustforce *  Time.deltaTime);
            
            if(!audioSource.isPlaying)  audioSource.Play();

            rb.AddRelativeForce( Vector3.down * thrustforce *  Time.deltaTime);
            audioSource.Stop();  
    }

    public void RotateLeft()
    { 
        ApplyRotation(rotationforce);
    }

    public void RotateRight()
    {
        ApplyRotation(-rotationforce);
    }

    private void ApplyRotation(float rotationValue)
    {
        rb.freezeRotation = true; 
        transform.Rotate(Vector3.forward * rotationValue * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
