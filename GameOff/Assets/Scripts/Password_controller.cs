using System.Collections.Generic;
using UnityEngine;

public class Password_controller : MonoBehaviour
{
    public string password = "2143";
    List<int> password_list = new List<int>();

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
        Debug.Log("Password is complete");
        //TODO: Add the code to open the door
    }
    void password_failed()
    {
        Debug.Log("Password is incorrect");
        //TODO: Add the code to shake the password slots
    }
}
