using UnityEngine;
using UnityEngine.UI;

public class Action_frame : MonoBehaviour
{
    public static Action_frame instance;
    void Awake()
    {
        if (instance == null)
            instance = this;


        
    }
    public void ActionFrame()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        Invoke("ActionFrameEnd", 0.8f);
    }
    void ActionFrameEnd()
    {
        gameObject.GetComponent<Animator>().enabled = false;
       
    }
}
