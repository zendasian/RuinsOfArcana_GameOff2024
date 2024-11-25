using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class password_input : MonoBehaviour
{
    [SerializeField]
    Password_controller password_Controller;
    public int password_number;
    bool is_active = true;
    GameObject status_anim;
    private void Start()
    {
        password_Controller = GetComponentInParent<Password_controller>();
        status_anim = GameObject.FindWithTag("puzzle_status");
    }
    private void OnMouseDown()
    {
        
        if (is_active)
        {
            is_active = false;
            password_Controller.set_password(password_number);
            status_anim.GetComponent<Animator>().SetInteger("status_num", status_anim.GetComponent<Animator>().GetInteger("status_num") + 1);

        }
    }
    public void reset_active()
    {
        is_active = true;
    }
}
