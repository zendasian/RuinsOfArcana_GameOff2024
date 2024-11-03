using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;
    private float  movementAxis = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

        movementAxis = Input.GetAxis("Horizontal");
         rb.linearVelocityX = Time.deltaTime * speed * movementAxis;
        
           
    }
}
