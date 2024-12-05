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

    private void OnMouseEnter()
    {
        if (FindFirstObjectByType<Inventory_manager>().tempItem == null)
            UnityEngine.Cursor.SetCursor(GlobalVariable.instance.eye_cursor, new Vector2(24, 24), CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        if (FindFirstObjectByType<Inventory_manager>().tempItem == null)
            UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseDown()
    {
        if (inventory_manager.item.Contains(item))
        {
            animator.SetBool("DoorOpen", true);
            StartCoroutine("AccessGranted");
        }
        else
        {
            animator.SetBool("AccessDenied", true);
            Audio_Manager.instance.Play("Access_denied");
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
        GlobalVariable.instance.is_cutscene = true;
        DialogueSystem dialogueSystem = FindFirstObjectByType<DialogueSystem>();
        dialogueSystem.DisplayDialogue(">Door: \"##### ##### ##### ####............\"");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Door: \"Analysis complete. Lifeform type: Human.\"");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Door: \"Access: Denied.\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">Player: \"I.....I have to see what's in there. I have to....\"");
        GlobalVariable.instance.is_cutscene = false;



        yield return null;
    }
    IEnumerator AccessGranted()
    {
        GlobalVariable.instance.is_cutscene = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        DialogueSystem dialogueSystem = FindFirstObjectByType<DialogueSystem>();
        dialogueSystem.DisplayDialogue(">Door: \"Analysis complete, Lifeform type: Human\"");
        FindFirstObjectByType<Inventory_manager>().deleteslot(0, item);
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Door:\"Access\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">Door: \"Denied\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">Door: \"Authorized personnel detected.\"");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Door: \"Access\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">Door: \"Granted\"");
        yield return new WaitForSeconds(4f);
        GlobalVariable.instance.is_cutscene = false;
        GlobalVariable.instance.is_next_lvl = true;
        Scene_manager.instance.startIenum(true);





        yield return null;
    }
}
