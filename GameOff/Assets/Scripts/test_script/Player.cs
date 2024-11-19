using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;
    private float  movementAxis = 0f;

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
    
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "items")
    //    {
    //        Items thisitem = collision.gameObject.GetComponent<Items_Object>().item;

    //        collision.gameObject.SetActive(false);
    //        FindFirstObjectByType<Inventory_manager>().Additems(thisitem);
    //    }


    //}
}
