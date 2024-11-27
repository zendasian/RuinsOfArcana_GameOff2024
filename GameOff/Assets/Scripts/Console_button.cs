using UnityEngine;
using UnityEngine.Events;

public class Console_button : MonoBehaviour
{
    public UnityEvent redbuttonPressed;
    GameObject console;
   
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
}

}
