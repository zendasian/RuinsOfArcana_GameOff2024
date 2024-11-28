using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventory_manager : MonoBehaviour
{

    public List<Items> item = new List<Items>();
    [SerializeField]
    List<GameObject> Slots = new List<GameObject>();


    public Items OGSlot;

    public Items tempItem;
    public int tempslotnum;

    List<int> Emptyslots = new List<int>();

    bool iscustomCursor = false;

    [SerializeField]
    List<Items> craft_output = new List<Items>();

    public void Start()
    {
        Emptyslots.AddRange(new int[] { 0, 1, 2, 3 });

    }
    private void Update()
    {
        if (iscustomCursor && Input.GetMouseButtonDown(1))
        {
            setcursordefault();
        }
    }
    public void Additems(Items otheritem, GameObject othergameobject)
    {
        if (iscustomCursor == false)
        {
            item.Add(otheritem);
            if (item != null)
            {
                Slots[Emptyslots[0]].GetComponent<Item_UI>().slotItem = otheritem;
                Emptyslots.RemoveAt(0);
                if (othergameobject != null)
                {
                    othergameobject.SetActive(false);
                }
                iscustomCursor = false;
            }
        }
    }
    public void ItemIntractions(int slotindex, Items otherItem)
    {
        if (item != null)
        {
            if (otherItem.Actions.Contains("key"))
            {
                deleteslot(slotindex, otherItem);
                setcursordefault();
            }
            else if (iscustomCursor == false)
            {


                tempItem = otherItem;
                tempslotnum = slotindex;
                iscustomCursor = true;
                Debug.Log(tempItem.name + " - " + tempItem.Actions[0]);
                UnityEngine.Cursor.SetCursor(otherItem.cursor, new Vector2(0, 0), CursorMode.Auto);

            }
            else if (iscustomCursor && otherItem.Actions.Contains("head") && tempItem.Actions.Contains("stick"))
            {
                deleteslot(slotindex, otherItem);
                deleteslot(tempslotnum, tempItem);
                setcursordefault();
                Additems(craft_output[0], null);
                FindFirstObjectByType<DialogueSystem>().DisplayDialogue(">Player: \"Lets go hunting\"");
            }
            else if (iscustomCursor && otherItem.Actions.Contains("stick") && tempItem.Actions.Contains("head"))
            {
                deleteslot(slotindex, otherItem);
                deleteslot(tempslotnum, tempItem);
                setcursordefault();
                FindFirstObjectByType<DialogueSystem>().DisplayDialogue(">Player: \"Lets go hunting\"");
                Additems(craft_output[0], null);
            }
            

        }
    }


    public void GameObjectInteraction(GameObject othergameobject)
    {
        if (tempItem.Actions.Contains("Stone"))
        {
            Destroy(othergameobject);
            GameObject.FindFirstObjectByType<DialogueSystem>().DisplayDialogue(">Player: Fuck that shard analysis anyways, I got an entire temple analysis.");
            deleteslot(tempslotnum, tempItem);
            setcursordefault();
            GlobalVariable.instance.is_window_block_remove = true;
            Action_frame.instance.ActionFrame();
        }
    }

    public void deleteslot(int slotindex, Items otheritem)
    {
        Slots[slotindex].GetComponent<Item_UI>().slotItem = OGSlot;
        item.Remove(otheritem);
        Emptyslots.Add(slotindex);

        //slotnum--;
    }

    public void setcursordefault()
    {
        UnityEngine.Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.Auto);
        iscustomCursor = false;
        tempItem = null;
        tempslotnum = 0;
    }
}
