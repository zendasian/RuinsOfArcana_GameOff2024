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
        
        if (is_active)
        {
            is_active = false;
            password_Controller.set_password(password_number);
            status_anim.GetComponent<Animator>().SetBool("is_active", true);

        }
    }
    public void reset_active()
    {
        is_active = true;
    }
}
