using UnityEngine;
using UnityEngine.UI;

public class Item_usage : MonoBehaviour
{
    public int Slotindex;
 

    private void Update()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Onbuttonpressed()
    {
       FindFirstObjectByType<Inventory_manager>().removeitems(Slotindex);
    }

    
    
}
