using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class Inventory_manager : MonoBehaviour
{

    [SerializeField]
    List<Items> item = new List<Items>();
    [SerializeField]
    List<GameObject> Slots = new List<GameObject>();
    int slotnum = 0;

    public Items OGSlot;
    Items tempItem;
    int tempslotnum;

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
            if (item.Count != null)
            {
                Slots[Emptyslots[0]].GetComponent<Item_UI>().slotItem = otheritem;
                Emptyslots.RemoveAt(0);
                othergameobject.SetActive(false);
                iscustomCursor = false;
            }
        }
    }
    public void ItemIntractions(int slotindex, Items otherItem)
    {
        if (item != null)
        {
            if (otherItem.Actions != null)
            {
                if (otherItem.Actions.Contains("key"))
                {
                    deleteslot(slotindex,otherItem);
                    setcursordefault();
                }
                else if(iscustomCursor == false)
                {
                    Debug.Log("this is a stick");

                    tempItem = otherItem;
                    tempslotnum = slotindex;
                    iscustomCursor = true;

                    UnityEngine.Cursor.SetCursor(otherItem.cursor, new Vector2(0,0), CursorMode.Auto);

                }
                else if(iscustomCursor && otherItem.Actions.Contains("head") && tempItem.Actions.Contains("stick"))
                {
                    deleteslot(slotindex, otherItem);
                    deleteslot(tempslotnum, tempItem);
                    setcursordefault();
                    Additems(craft_output[0], null);
                }
                else if (iscustomCursor && otherItem.Actions.Contains("stick") && tempItem.Actions.Contains("head"))
                {
                    deleteslot(slotindex, otherItem);
                    deleteslot(tempslotnum, tempItem);
                    setcursordefault();
                    Additems(craft_output[0], null);
                    

                }
            }
        }
    }

    void deleteslot(int slotindex, Items otheritem)
    {
        Slots[slotindex].GetComponent<Item_UI>().slotItem = OGSlot;
        item.RemoveAt(slotindex);
        Emptyslots.Add(slotindex);
        
        //slotnum--;
    }

    void setcursordefault()
    {
        UnityEngine.Cursor.SetCursor(null, new Vector2(0, 0), CursorMode.Auto);
        iscustomCursor = false;
        tempItem = null;
        tempslotnum = 0;
    }
}
