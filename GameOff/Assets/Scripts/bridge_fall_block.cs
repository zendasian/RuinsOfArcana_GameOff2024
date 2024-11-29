using System;
using Unity.VisualScripting;
using UnityEngine;

public class bridge_fall_block : MonoBehaviour
{
    public bool is_dilouge = false;
    public string dialouge;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player" && !is_dilouge)
        {
            GameObject.FindFirstObjectByType<DialogueSystem>().DisplayDialogue(dialouge);
            is_dilouge = true;
        }
    }

}
