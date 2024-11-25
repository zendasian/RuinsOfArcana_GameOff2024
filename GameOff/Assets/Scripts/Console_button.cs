using UnityEngine;

public class Console_button : MonoBehaviour
{
    GameObject console;
   
    void Start()
    {
        console = transform.parent.gameObject;
       
    }

private void OnMouseDown() 
{
    console.GetComponent<Animator>().SetBool("is_active", true);
}
}
