using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
public class Skeli_controller : MonoBehaviour
{
    public Items item;
    public Items spaer_head;
    Inventory_manager inventory_manager;
    public UnityEvent on_skeli_done;
    public bool Is_dialouge = false;
    void Start()
    {
        inventory_manager = FindFirstObjectByType<Inventory_manager>();
    }

    void Update()
    {
        
    }
    private void OnMouseDown() 
    {
        if (inventory_manager.tempItem == item)
        {
            inventory_manager.deleteslot(3, item);
            inventory_manager.setcursordefault();
            on_skeli_done.Invoke();
            Audio_Manager.instance.Play("Skeleton_fall");
            FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"oh shit! that worked almost cracked my skull open but it worked\"");
        }
        if (inventory_manager.tempItem == spaer_head)
        {
            GameObject.FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player:\"Still too high. Even with this, can’t cut it down.\"");
            
            inventory_manager.setcursordefault();
        }
        if (!Is_dialouge)
        {
            StartCoroutine(Startclickdialouge());
        }
    }
    private IEnumerator Startclickdialouge()
    {
        if (!Is_dialouge)
        {
            GameObject.FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"No way… alien remains. The skeletal structure is similar to ours.\"");
            yield return new WaitForSeconds(6f);
            GameObject.FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"Looks like the fella from a height and got caught up there. Can't reach it from here\"");

            Is_dialouge = true;
        }
    }
    public void deleteObj()
    {
        inventory_manager.deleteslot(inventory_manager.tempslotnum, inventory_manager.tempItem);
    }

}
