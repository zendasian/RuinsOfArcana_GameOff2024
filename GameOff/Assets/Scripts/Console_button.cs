using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Console_button : MonoBehaviour
{
    public UnityEvent redbuttonPressed;
    GameObject console;
    bool is_dialouge = false;

    void Start()
    {
        console = transform.parent.gameObject;

    }

    private void OnMouseDown()
    {
        console.GetComponent<Animator>().SetBool("is_active", true);
        GlobalVariable.instance.is_console_on = true;
        GameObject.FindWithTag("console").GetComponent<Animator>().SetBool("is_on", true);
        redbuttonPressed.Invoke();
        if (!is_dialouge)
        {
            is_dialouge = true;
            StartCoroutine("Button_Dialuge");
        }

    }
    IEnumerator Button_Dialuge()
    {
        FindFirstObjectByType<Audio_Manager>().Play("Console_on");
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"Alright, here goes. Hope this doesn’t trigger another dark matter blast like on Forge World…\"");
        Destroy(gameObject);

        yield return null;
    }
    private void OnMouseEnter()
    {   
        UnityEngine.Cursor.SetCursor(GlobalVariable.instance.eye_cursor, new Vector2(24, 24), CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

}
