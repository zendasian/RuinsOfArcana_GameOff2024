using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_manager : MonoBehaviour
{

    [SerializeField]
    List<Items> item = new List<Items>();
    [SerializeField]
    List<GameObject> Slots = new List<GameObject>();
    int slotnum = 0;

    public Items OGSlot;

    List<int> Emptyslots = new List<int>();

    public void Start()
    {
        Emptyslots.AddRange(new int[] { 0, 1, 2, 3 });

    }
    public void Additems(Items otheritem)
    {
        item.Add(otheritem);
        if (item.Count != null)
        {
           Slots[Emptyslots[0]].GetComponent<Item_UI>().slotItem = otheritem;
           Emptyslots.RemoveAt(0);
           
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
                }
            }

        }
    }
    void objectActions(int slotindex, Items otheritem)
    {

    }
    void deleteslot(int slotindex, Items otheritem)
    {
        Slots[slotindex].GetComponent<Item_UI>().slotItem = OGSlot;
        item.RemoveAt(slotindex);
        Emptyslots.Add(slotindex);
        //slotnum--;
    }
}
