using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Password_controller : MonoBehaviour
{
    
    public string password = "2143";
    List<int> password_list = new List<int>();
    [SerializeField]
    List<GameObject> password_slots = new List<GameObject>();
    public UnityEvent onPasswordComplete;

    Animator[] status_anim = new Animator[4];

    private void Start() 
    {
        for (int i = 0; i < 4; i++)
        {
            status_anim[i] = GameObject.FindGameObjectsWithTag("puzzle_status")[i].GetComponent<Animator>();
        }
        int child_count = transform.childCount;
        for (int i = 0; i < child_count; i++)
        {
            password_slots.Add(transform.GetChild(i).gameObject);
        }
    }

    public void set_password(int pass)
    {
        password_list.Add(pass);

        if (password_list.Count == 4)
        {
            if (string.Join("", password_list) == password)
            {
                Password_complete();
            }
            else
            {
                password_failed();
            }
            password_list.Clear();
        }
    }
    void Password_complete()
    {
        onPasswordComplete.Invoke();
        
        //TODO: Add the code to open the door
    }
    void password_failed()
    {

        Debug.Log("Password is incorrect");
        for (int i = 0; i < 4; i++)
        {
            status_anim[i].SetBool("Failed", true);
        }

        //TODO: Add the code to shake the password slots
    }
    public void puzzle_complete_anim()
    {
        for (int i = 0; i < 4; i++)
        {
            status_anim[i].SetBool("complete", true);
        }
    }

    
}
