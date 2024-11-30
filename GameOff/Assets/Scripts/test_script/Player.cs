using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;
    private float movementAxis = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!GlobalVariable.instance.is_next_lvl)
        {
            transform.position = GameObject.FindWithTag("Spawn").transform.position;
        }
    }

    void Update()
    {
            // if (Input.GetKeyDown(KeyCode.X))
            //     GameObject.FindFirstObjectByType<DialogueSystem>().TextErase();s
    }
    private void FixedUpdate()
    {
        if(GlobalVariable.instance.is_Typing || GlobalVariable.instance.is_cutscene)
                this.GetComponent<Animator>().SetBool("is_walking", false);

        if (!GlobalVariable.instance.is_scanning && !GlobalVariable.instance.is_Typing && !GlobalVariable.instance.is_cutscene)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                this.GetComponent<Animator>().SetBool("is_walking", true);
            }
            else
            {
                this.GetComponent<Animator>().SetBool("is_walking", false);
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
           

            movementAxis = Input.GetAxis("Horizontal");
            rb.linearVelocityX = Time.deltaTime * speed * movementAxis;
        }


    }
    public void footStep_1()
    {
        FindFirstObjectByType<Audio_Manager>().Play("Foot_1");
    }
        public void footStep_2()
    {
        FindFirstObjectByType<Audio_Manager>().Play("Foot_2");
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
