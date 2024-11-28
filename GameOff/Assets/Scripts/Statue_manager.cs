using UnityEngine;
using UnityEngine.Events;
public class Statue_manager : MonoBehaviour
{
    [SerializeField]
    GameObject[] statues;
    public UnityEvent on_statue_done;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (statues[0].GetComponent<Statue_click>().is_spearDown && statues[1].GetComponent<Statue_click>().is_spearDown)
        {
            on_statue_done.Invoke();
            GlobalVariable.instance.is_statue_down = true;
        }
        if (GlobalVariable.instance.is_statue_down)
        {
            on_statue_done.Invoke();
        }
    }
    public void statue_down()
    {
        FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"No… way.\"");
    }
}
