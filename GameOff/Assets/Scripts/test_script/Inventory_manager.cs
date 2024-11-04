using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_manager : MonoBehaviour
{

    
    List<Items> item = new List<Items>();
    public List<Image> images = new List<Image>();
    int slotnum = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Additems(Items otheritem)
    {
        item.Add(otheritem);
        if (item != null)
        {
            images[slotnum].GetComponent<Image>().sprite = item[slotnum].icon;
            slotnum++;
        }
        
    }
    public void removeitems()
    {

    }
}
