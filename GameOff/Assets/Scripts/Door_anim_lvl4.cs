using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Collections.Generic;
public class Door_anim_lvl4 : MonoBehaviour
{
    Animator animator;
    Inventory_manager inventory_manager;
    public Items item;
    bool is_dialouge = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        inventory_manager = FindFirstObjectByType<Inventory_manager>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnMouseDown()
    {
        if (inventory_manager.item.Contains(item))
        {
            animator.SetBool("DoorOpen", true);
        }
        else
        {
            animator.SetBool("AccessDenied", true);
            if (!is_dialouge)
            {
                is_dialouge = true;
                StartCoroutine("AccessDenied");
            }
        }
    }
    public void ResetAccessDenied()
    {
        animator.SetBool("AccessDenied", false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    IEnumerator AccessDenied()
    {
        DialogueSystem dialogueSystem = FindFirstObjectByType<DialogueSystem>();
        dialogueSystem.DisplayDialogue(">Door: \"##### ##### ##### ####............\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">Door: \"Analysis complete. Lifeform type: Human.\"");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Door: \"Access: Denied.\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">Player: \"I.....I have to see what's in there. I have to....\"");

        yield return null;
    }
}
