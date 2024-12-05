using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;

public class Item_UI : MonoBehaviour
{
    public int Slotindex;


    public Items slotItem;
   
    private void Update()
    {
        if (slotItem != null)
        {
            gameObject.GetComponent<Image>().sprite = slotItem.icon;
        }
    }
    
   public void onclick()
    {
        if(slotItem != GlobalVariable.instance.EmptySlot && slotItem != null)
        gameObject.GetComponentInParent<Inventory_manager>().ItemIntractions(Slotindex, slotItem);


    }

    
    
}
