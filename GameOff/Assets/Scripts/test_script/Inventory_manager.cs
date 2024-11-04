using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_manager : MonoBehaviour
{

    [SerializeField]
    List<Items> item = new List<Items>();
    public List<Image> images = new List<Image>();
    int slotnum = 0;
    public Sprite OGSlot;

    List<int> Emptyslots = new List<int>();

    public void Start()
    {
        Emptyslots.AddRange(new int[] { 0, 1, 2, 3 });
    }
    public void Additems(Items otheritem)
    {
        item.Add(otheritem);
        if (item != null)
        {
           images[Emptyslots[0]].GetComponent<Image>().sprite = item[slotnum].icon;
            Emptyslots.RemoveAt(0);
            slotnum++;
        }
    }
    public void removeitems(int slotindex)
    {
        if (item != null)
        {

            images[slotindex].GetComponent<Image>().sprite = OGSlot;
            item.RemoveAt(slotindex);
            Emptyslots.Add(slotindex);
            slotnum--;
            
            
           
        }
    }
}
