using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Obselisk : MonoBehaviour
{
    bool isplayercollidig = false;
    [SerializeField, HideInInspector]
    public bool isright;
    bool is_dilouge = false;
    public float correctangle;

    [SerializeField]
    float rotationangle = 0f;

    
    public bool isagnglecorrect = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.eulerAngles = new Vector3(0,rotationangle,0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E) && isplayercollidig && !GlobalVariable.instance.is_obs_correct)
        {
            
        }
        */
        // Define a threshold for angle comparison
        const float angleThreshold = 0.1f; // Adjust as necessary

        if (Mathf.Abs(Mathf.DeltaAngle(0, transform.localEulerAngles.y) - correctangle) < angleThreshold)
        {
            isagnglecorrect = true;
        }
        else
        isagnglecorrect = false;
    }
    void OnMouseDown()
    {
        if (!GlobalVariable.instance.is_obs_correct && !GlobalVariable.instance.is_Typing)
        {
            rotationangle += 120f;
            transform.eulerAngles = new Vector3(0,rotationangle,0);

            Audio_Manager.instance.Play("Crystal_move");
            
            if (!GlobalVariable.instance.is_glyph_dialouge)
            {
                FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"These symbols… they must mean something. But what?\"");
                GlobalVariable.instance.is_glyph_dialouge = true;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            isplayercollidig=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            isplayercollidig = false;
        }
    }
}
