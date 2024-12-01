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
    
    FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"Alright, here goes. Hope this doesn’t trigger another dark matter blast like on Forge World…\"");
    Destroy(gameObject);

    yield return null;
}

}
