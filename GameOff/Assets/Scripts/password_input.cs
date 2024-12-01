using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class password_input : MonoBehaviour
{
    [SerializeField]
    Password_controller password_Controller;
    public int password_number;
    bool is_active = true;
    public GameObject status_anim;
    private void Start()
    {
        password_Controller = GetComponentInParent<Password_controller>();

    }
    private void OnMouseDown()
    {

        if (is_active && GlobalVariable.instance.is_console_on)
        {
            is_active = false;
            password_Controller.set_password(password_number);
            status_anim.GetComponent<Animator>().SetBool("is_active", true);

        }
        if (!GlobalVariable.instance.is_console_on)
        {
            FindFirstObjectByType<DialogueSystem>().DisplayDialogue(">Player: \"Nothing happened\"");
        }
    }
    public void reset_active()
    {
        is_active = true;

    }
    private void OnMouseEnter()
    {
        if (is_active)
            UnityEngine.Cursor.SetCursor(GlobalVariable.instance.eye_cursor, new Vector2(24, 24), CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
